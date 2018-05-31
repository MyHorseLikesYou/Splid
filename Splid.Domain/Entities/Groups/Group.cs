using MyApp.Core.Contracts;
using MyApp.Core.Domain;
using Splid.Domain.Main.Values;
using Splid.Domain.Models.Groups;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Splid.Domain.Main.Entities.Groups
{
    public sealed class Group : Entity, IAgregateRoot
    {
        private string _name;
        public string Name
        {
            private get => _name;
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                    throw new ArgumentException(nameof(Group.Name), "Имя группы не может быть пустым.");

                _name = value;
            }
        }

        private List<Person> _persons;
        private List<Payment> _payments;
        private List<Expense> _expenses;
        private Guid groupId;
        private GroupInput groupInput;

        public Group(Guid groupId, string name)
            : this(groupId, name, new List<Person>(), new List<Payment>(), new List<Expense>())
        { }

        public Group(Guid groupId, string name, IEnumerable<Person> persons, IEnumerable<Payment> payments, IEnumerable<Expense> expenses)
            : base(groupId)
        {
            if (persons == null)
                throw new ArgumentNullException(nameof(persons));

            if (payments == null)
                throw new ArgumentNullException(nameof(payments));

            if (expenses == null)
                throw new ArgumentNullException(nameof(expenses));

            this.Name = name;
            _persons = persons.ToList();
            _payments = payments.ToList();
            _expenses = expenses.ToList();
        }

        internal void Change(GroupInput groupInput)
        {
            throw new NotImplementedException();
        }

        public Group(Guid groupId, GroupInput groupInput)
            :this(groupId, groupInput?.Name)
        { }

        public Group AddPersons(IEnumerable<Person> persons)
        {
            throw new NotImplementedException();
        }

        private void AddPerson(Person person)
        {
            if (person == null)
                throw new ArgumentNullException(nameof(person));

            if (this.HasPerson(person))
                throw new ArgumentException(nameof(person), $"Участник c Id {person.Id} уже есть в группе.");

            if (this.HasPersonWithName(person.Name))
                throw new ArgumentException(nameof(person), $"Участник c именем {person.Name} уже есть в группе.");

            _persons.Add(person);
        }

        public Group ChangeName(string name)
        {
            throw new NotImplementedException();
        }

        private bool HasPerson(Person person)
        {
            if (person == null)
                throw new ArgumentNullException(nameof(person));

            return _persons.Contains(person);
        }

        private bool HasPersonWithId(Guid id)
        {
            return _persons.Any(p => p.Id == id);
        }

        private bool HasPersonWithName(string personName)
        {
            if (String.IsNullOrWhiteSpace(personName))
                return false;

            return _persons.Any(p => p.Name == personName);
        }

        public void AddPayment(PaymentInput paymentInput)
        {
            this.AddPayment(new Payment(paymentInput));
        }

        private void AddPayment(Payment payment)
        {
            if (payment == null)
                throw new ArgumentNullException(nameof(payment));

            if (this.HasPayment(payment))
                throw new ArgumentException(nameof(payment), $"Платёж c Id {payment.Id} уже есть в группе.");

            if (!this.HasPersonWithId(payment.PersonFromId))
                throw new ArgumentException(nameof(Payment.PersonFromId), $"Участник c Id {payment.PersonFromId} не привязан к группе.");

            if (!this.HasPersonWithId(payment.PersonToId))
                throw new ArgumentException(nameof(Payment.PersonToId), $"Участник c Id {payment.PersonToId} не привязан к группе.");

            _payments.Add(payment);
        }

        internal void AddExpense(ExpenseInput expenseInput)
        {
            throw new NotImplementedException();
        }

        public void ChangePayment(PaymentInput paymentInput)
        {
            this.ChangePayment(paymentInput.Id, paymentInput.PersonFromId, paymentInput.PersonToId, paymentInput.Amount, paymentInput.Date);
        }

        internal void ChangePayment(ExpenseInput expenseInput)
        {
            throw new NotImplementedException();
        }

        public void ChangePayment(Guid paymentId, Guid personFromId, Guid personToId, Money amount, DateTime date)
        {
            var payment = this.GetPayment(paymentId);
            if (payment == null)
                throw new ArgumentNullException(nameof(payment));

            if (!this.HasPersonWithId(personFromId))
                throw new ArgumentException(nameof(Payment.PersonFromId), $"Участник c Id {payment.PersonFromId} не привязан к группе.");

            if (!this.HasPersonWithId(personToId))
                throw new ArgumentException(nameof(Payment.PersonToId), $"Участник c Id {payment.PersonToId} не привязан к группе.");

            payment.PersonFromId = personFromId;
            payment.PersonToId = personToId;
            payment.Amount = amount;
            payment.Date = date;
        }

        internal void ChangeExpense(ExpenseInput expenseInput)
        {
            throw new NotImplementedException();
        }

        internal void AddPerson(PersonInput personInput)
        {
            throw new NotImplementedException();
        }

        private bool HasPayment(Payment payment)
        {
            if (payment == null)
                throw new ArgumentNullException(nameof(payment));

            return _payments.Contains(payment);
        }

        internal void ChangePerson(PersonInput personInput)
        {
            throw new NotImplementedException();
        }

        private Payment GetPayment(Guid id)
        {
            return _payments.FirstOrDefault(e => e.Id == id);
        }

        public void DelelePayment(Guid id)
        {
            var payment = this.GetPayment(id);
            if (payment == null)
                throw new InvalidOperationException();

            _payments.Remove(payment);
        }

        internal void DeletePerson(Guid personId)
        {
            throw new NotImplementedException();
        }

        public void AddExpense(string title, IDictionary<Guid, Money> expensesBy, IDictionary<Guid, Money> expensesFor, DateTime date)
        {
            //this.AddExpense(new Expense(title, expensesBy, expensesFor, date));
        }

        private void AddExpense(Expense expense)
        {
            if (expense == null)
                throw new ArgumentNullException(nameof(expense));

            if (this.HasExpense(expense))
                throw new ArgumentException(nameof(expense), $"Трата c Id {expense.Id} уже есть в группе.");

            var notBelongingToGroupPersonsIds = new List<Guid>();
            notBelongingToGroupPersonsIds.AddRange(expense.GetPersonsExpensesBy().Where(id => !this.HasPersonWithId(id)));
            notBelongingToGroupPersonsIds.AddRange(expense.GetPersonsExpensesFor().Where(id => !this.HasPersonWithId(id)));
            if (notBelongingToGroupPersonsIds.Any())
                throw new ArgumentException(nameof(expense), $"Участник(и) c Id {String.Join(", ", notBelongingToGroupPersonsIds)} не привязаны к группе.");

            _expenses.Add(expense);
        }

        public void ChangeExpense(Guid expenseId, string title, IDictionary<Guid, Money> expensesBy, IDictionary<Guid, Money> expensesFor, DateTime date)
        {
            var expense = this.GetExpense(expenseId);
            if (expense == null)
                throw new InvalidOperationException();

            var notBelongingToGroupPersonsIds = new List<Guid>();
            notBelongingToGroupPersonsIds.AddRange(expensesBy.Where(e => !this.HasPersonWithId(e.Key)).Select(e => e.Key));
            notBelongingToGroupPersonsIds.AddRange(expensesFor.Where(e => !this.HasPersonWithId(e.Key)).Select(e => e.Key));
            if (notBelongingToGroupPersonsIds.Any())
                throw new ArgumentException(nameof(expense), $"Участник(и) c Id {String.Join(", ", notBelongingToGroupPersonsIds)} не привязаны к группе.");

            expense.Title = title;
            expense.Date = date;
            expense.SetExpensesBy(expensesBy);
            expense.SetExpensesFor(expensesFor);
        }

        public void DeleteExpense(Guid expenseId)
        {
            var expense = this.GetExpense(expenseId);
            if (expense == null)
                throw new InvalidOperationException();

            _expenses.Remove(expense);
        }

        private bool HasExpense(Expense expense)
        {
            if (expense == null)
                throw new ArgumentNullException(nameof(expense));

            return _expenses.Contains(expense);
        }

        private Expense GetExpense(Guid id)
        {
            return _expenses.FirstOrDefault(e => e.Id == id);
        }
    }
}
