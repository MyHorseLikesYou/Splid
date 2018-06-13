using MyApp.Core.Contracts;
using MyApp.Core.Domain;
using Splid.Domain.Models.Groups;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Splid.Domain.Main.Entities.Groups
{
    public sealed class Group : Entity, IAgregateRoot
    {
        private string _name;
        private List<Person> _persons;
        private List<Payment> _payments;
        private List<GroupExpense> _expenses;        

        public Group(Guid groupId, string name, IEnumerable<Person> persons, IEnumerable<Payment> payments, IEnumerable<GroupExpense> expenses)
            : base(groupId)
        {
            ValidateArgumentForName(name);
            ValidateArgumentForPersons(persons);
            ValidateArgumentForPayments(payments);
            ValidateArgumentForExpenses(expenses);

            ValidatePersonsNotHaveDuplicateName(persons);

            foreach (var payment in payments)
                ValidatePaymentNotHaveUnknownPersons(payment.PersonFromId, payment.PersonToId, persons);

            foreach (var expense in expenses)
            {
                var expensesByPersonsIds = expense.ExpensesBy.Select(e => e.PersonId).ToList();
                var expensesForPersonsIds = expense.ExpensesFor.Select(e => e.PersonId).ToList();
                ValidateExpenseNotHaveUnknownPersons(expensesByPersonsIds, expensesForPersonsIds, persons);
            }

            _name = name;
            _persons = persons.ToList();
            _payments = payments.ToList();
            _expenses = expenses.ToList();
        }

        public string Name => _name;

        public IReadOnlyCollection<GroupExpense> Expenses => _expenses;

        public IReadOnlyCollection<Payment> Payments => _payments;

        public IReadOnlyCollection<Person> Persons => _persons;

        public void Change(GroupInput groupInput)
        {
            if (groupInput == null)
                throw new ArgumentNullException();

            ValidateArgumentForName(groupInput.Name);

            _name = groupInput.Name;
        }

        public void AddPayment(Guid paymentId, PaymentInput paymentInput)
        {
            if (paymentInput == null)
                throw new ArgumentNullException(nameof(paymentInput));

            ValidatePaymentNotHaveUnknownPersons(paymentInput.PersonById, paymentInput.PersonForId, _persons);

            var paymentById = this.GetPaymentById(paymentId);
            if (paymentById != null)
                throw new ArgumentException($"Платёж c Id {paymentById.Id} уже есть в группе.");

            var paymentToAdd = Payment.Create(paymentId, paymentInput);
            _payments.Add(paymentToAdd);
        }

        public void ChangePayment(Guid paymentId, PaymentInput paymentInput)
        {
            if (paymentInput == null)
                throw new ArgumentNullException(nameof(paymentInput));

            ValidatePaymentNotHaveUnknownPersons(paymentInput.PersonById, paymentInput.PersonForId, _persons);

            var paymentToChange = this.GetPaymentById(paymentId);
            if (paymentToChange == null)
                throw new ArgumentException($"Платежа c Id {paymentToChange.Id} нет в группе.");

            paymentToChange.Change(paymentInput);
        }

        public void DeletePayment(Guid id)
        {
            var payment = this.GetPaymentById(id);
            if (payment == null)
                throw new InvalidOperationException();

            _payments.Remove(payment);
        }

        public void AddGroupExpense(Guid expenseId, GroupExpenseInput expenseInput)
        {
            if (expenseInput == null)
                throw new ArgumentNullException(nameof(expenseInput));

            ValidateExpenseNotHaveUnknownPersons(expenseInput.Payments.Select(e => e.PersonId), expenseInput.Expenses.Select(e => e.PersonId), _persons);

            var expenseById = this.GetExpenseById(expenseId);
            if (expenseById != null)
                throw new ArgumentException($"Трата c Id {expenseId} уже есть в группе.");

            var expenseToAdd = GroupExpense.Create(expenseId, expenseInput);
            _expenses.Add(expenseToAdd);
        }

        public void ChangeGroupExpense(Guid expenseId, GroupExpenseInput expenseInput)
        {
            if (expenseInput == null)
                throw new ArgumentNullException(nameof(expenseInput));

            ValidateExpenseNotHaveUnknownPersons(expenseInput.Payments.Select(e => e.PersonId), expenseInput.Expenses.Select(e => e.PersonId), _persons);

            var expenseToChange = this.GetExpenseById(expenseId);
            if (expenseToChange == null)
                throw new ArgumentException($"Траты c Id {expenseId} нет в группе.");

            expenseToChange.Change(expenseInput);
        }

        public void DeleteExpense(Guid expenseId)
        {
            var expense = this.GetExpenseById(expenseId);
            if (expense == null)
                throw new InvalidOperationException();

            _expenses.Remove(expense);
        }

        public void AddPerson(Guid personId, PersonInput personInput)
        {
            if (personInput == null)
                throw new ArgumentNullException(nameof(personInput));

            var personById = this.GetPersonById(personId);
            if (personById != null)
                throw new ArgumentException($"Участник c Id {personId} уже есть в группе.");

            var personByName = this.GetPersonByName(personInput.Name);
            if (personByName != null)
                throw new ArgumentException($"Участник c именем {personInput.Name} уже есть в группе.");

            var personToAdd = Person.Create(personId, personInput);
            _persons.Add(personToAdd);
        }

        public void ChangePerson(Guid personId, PersonInput personInput)
        {
            if (personInput == null)
                throw new ArgumentNullException(nameof(personInput));

            var personByName = this.GetPersonByName(personInput.Name);
            if (personByName != null && personByName.Id != personId)
                throw new ArgumentException($"Участник c именем {personInput.Name} уже есть в группе.");

            var personToChange = personByName ?? this.GetPersonById(personId);
            if (personToChange == null)
                throw new ArgumentException($"Участника c Id {personId} нет в группе.");

            personToChange.Change(personInput);
        }

        public void DeletePerson(Guid personId)
        {
            var person = this.GetPersonById(personId);
            if (person == null)
                throw new ArgumentException($"Участника c Id {personId} нет в группе.");

            _persons.Remove(person);
        }

        private Payment GetPaymentById(Guid paymentId) => _payments.FirstOrDefault(e => e.Id == paymentId);

        private GroupExpense GetExpenseById(Guid expenseId) => _expenses.FirstOrDefault(e => e.Id == expenseId);

        private Person GetPersonById(Guid personId) => _persons.SingleOrDefault(p => p.Id == personId);

        private Person GetPersonByName(string personName) => _persons.SingleOrDefault(p => p.Name == personName);

        private bool HasPersonWithSameId(Guid personId) => HasPersonWithSameId(personId, _persons);

        private bool HasPersonWithSameName(string personName) => _persons.Any(p => p.Name == personName);

        private void ValidatePersonsNotHaveDuplicateName(IEnumerable<Person> persons)
        {
            var personsHaveDuplicatesByName = persons
                .GroupBy(p => p.Name)
                .Select(personsByName => personsByName.Count())
                .Any(countByName => countByName > 1);

            if (personsHaveDuplicatesByName)
                throw new ArgumentException();
        }

        private static void ValidateExpenseNotHaveUnknownPersons(IEnumerable<Guid> expensesByPersonsIds, IEnumerable<Guid> expensesForPersonsIds, IEnumerable<Person> groupPersons)
        {
            var unkownPersonsIds = Enumerable
                .Concat(expensesByPersonsIds, expensesForPersonsIds)
                .Where(personId => !HasPersonWithSameId(personId, groupPersons))
                .ToList();

            if (unkownPersonsIds.Any())
                throw new ArgumentException($"Участник(и) c Id {String.Join(", ", unkownPersonsIds)} не привязан(ы) к группе.");
        }

        private static void ValidatePaymentNotHaveUnknownPersons(Guid paymentByPersonId, Guid paymentForPersonId, IEnumerable<Person> persons)
        {
            if (!HasPersonWithSameId(paymentByPersonId, persons))
                throw new ArgumentException($"Участник c Id {paymentByPersonId} не привязан к группе.");

            if (!HasPersonWithSameId(paymentForPersonId, persons))
                throw new ArgumentException($"Участник c Id {paymentForPersonId} не привязан к группе.");
        }

        private static bool HasPersonWithSameId(Guid personId, IEnumerable<Person> persons)
        {
            return persons.Any(p => p.Id == personId);
        }

        private static void ValidateArgumentForName(string name)
        {
            if (String.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Имя группы не может быть пустым.");
        }

        private static void ValidateArgumentForPayments(IEnumerable<Payment> payments)
        {
            if (payments == null)
                throw new ArgumentNullException(nameof(payments));
        }

        private static void ValidateArgumentForExpenses(IEnumerable<GroupExpense> expenses)
        {
            if (expenses == null)
                throw new ArgumentNullException(nameof(expenses));
        }

        private static void ValidateArgumentForPersons(IEnumerable<Person> persons)
        {
            if (persons == null)
                throw new ArgumentNullException(nameof(persons));
        }

        public static Group Create(Guid groupId, GroupInput groupInput)
        {
            if (groupInput == null)
                throw new ArgumentNullException(nameof(groupInput));

            return new Group(groupId, groupInput.Name, new List<Person>(), new List<Payment>(), new List<GroupExpense>());
        }
    }
}
