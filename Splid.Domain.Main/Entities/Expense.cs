using System;
using System.Collections.Generic;
using System.Linq;
using MyApp.Core.Domain;
using MyApp.Core.Extensions;
using Splid.Domain.Main.Models;
using Splid.Domain.Main.Values;

namespace Splid.Domain.Main.Entities
{
    public class GroupExpense : Entity
    {
        private string _title;
        private List<PersonMoneyOperation> _personPayments;
        private List<PersonMoneyOperation> _personExpenses;
        private DateTimeOffset _date;

        public GroupExpense(Guid id, string title, IEnumerable<PersonMoneyOperation> personPayments,
            IEnumerable<PersonMoneyOperation> personExpenses, DateTimeOffset date, DateTimeOffset createdAt)
            : base(id)
        {
            ValidateTitle(title);
            ValidateDate(date);
            ValidatePayments(personPayments);
            ValidateExpenses(personExpenses);

            _title = title;
            _personPayments = personPayments.ToList();
            _personExpenses = personExpenses.ToList();
            _date = date;
        }

        public IReadOnlyCollection<PersonMoneyOperation> ExpensesFor => _personExpenses;
        public IReadOnlyCollection<PersonMoneyOperation> ExpensesBy => _personPayments;
        public Guid GroupId { get; set; }

        public void Change(GroupExpenseInput groupExpenseInput)
        {
            if (groupExpenseInput == null)
                throw new ArgumentNullException();

            ValidateTitle(groupExpenseInput.Title);
            ValidatePayments(groupExpenseInput.Payments);
            ValidateExpenses(groupExpenseInput.Expenses);
            Validate(groupExpenseInput.Expenses, groupExpenseInput.Payments);
            ValidateDate(groupExpenseInput.Date);

            _title = groupExpenseInput.Title;
            _personPayments = groupExpenseInput.Payments.ToList();
            _personExpenses = groupExpenseInput.Expenses.ToList();
            _date = groupExpenseInput.Date;
        }

        private static void ValidateTitle(string title)
        {
            if (String.IsNullOrWhiteSpace(title))
                throw new ArgumentException("Название траты не может быть пустым.");
        }

        private static void ValidateDate(DateTimeOffset date)
        {
            if (date.IsInFuture())
                throw new ArgumentException("Дата траты не может быть в будующем.");
        }

        private static void ValidateExpenses(IEnumerable<PersonMoneyOperation> expenses)
        {
            if (expenses == null)
                throw new ArgumentNullException(nameof(expenses));

            if (!expenses.Any() || HaveNull(expenses) || HaveZeroAmount(expenses) || HaveDuplicatePersons(expenses))
                throw new ArgumentException(nameof(expenses));
        }

        private static void ValidatePayments(IEnumerable<PersonMoneyOperation> payments)
        {
            if (payments == null)
                throw new ArgumentNullException(nameof(payments));

            if (!payments.Any() || HaveNull(payments) || HaveZeroAmount(payments) || HaveDuplicatePersons(payments))
                throw new ArgumentException(nameof(payments));
        }

        private static void Validate(List<PersonMoneyOperation> expenses, List<PersonMoneyOperation> payments)
        {
            if (expenses.Sum(e => e.Amount.Value) != payments.Sum(p => p.Amount.Value))
                throw new ArgumentException();
        }

        private static bool HaveNull(IEnumerable<PersonMoneyOperation> operations) => operations.Any(o => o == null);

        private static bool HaveZeroAmount(IEnumerable<PersonMoneyOperation> operations) =>
            operations.Any(o => o.Amount.Value == 0);

        private static bool HaveDuplicatePersons(IEnumerable<PersonMoneyOperation> operations) =>
            operations
                .GroupBy(e => e.PersonId)
                .Any(expensesByPerson => expensesByPerson.Count() > 1);

        public static GroupExpense Create(Guid groupExpenseId, GroupExpenseInput groupExpenseInput)
        {
            if (groupExpenseInput == null)
                throw new ArgumentNullException();

            return new GroupExpense(groupExpenseId, groupExpenseInput.Title, groupExpenseInput.Payments,
                groupExpenseInput.Expenses, groupExpenseInput.Date, DateTimeOffset.Now);
        }
    }
}