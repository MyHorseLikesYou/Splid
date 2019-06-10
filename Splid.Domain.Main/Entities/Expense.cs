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
        private List<MoneyOperation> _personPayments;
        private List<MoneyOperation> _personExpenses;
        private DateTimeOffset _date;

        public GroupExpense(Guid id, string title, IEnumerable<MoneyOperation> personPayments,
            IEnumerable<MoneyOperation> personExpenses, DateTimeOffset date, DateTimeOffset createdAt)
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

        public IReadOnlyCollection<MoneyOperation> ExpensesFor => _personExpenses;
        public IReadOnlyCollection<MoneyOperation> ExpensesBy => _personPayments;
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

        private static void ValidateExpenses(IEnumerable<MoneyOperation> expenses)
        {
            if (expenses == null)
                throw new ArgumentNullException(nameof(expenses));

            if (!expenses.Any() || HaveNull(expenses) || HaveZeroAmount(expenses) || HaveDuplicatePersons(expenses))
                throw new ArgumentException(nameof(expenses));
        }

        private static void ValidatePayments(IEnumerable<MoneyOperation> payments)
        {
            if (payments == null)
                throw new ArgumentNullException(nameof(payments));

            if (!payments.Any() || HaveNull(payments) || HaveZeroAmount(payments) || HaveDuplicatePersons(payments))
                throw new ArgumentException(nameof(payments));
        }

        private static void Validate(List<MoneyOperation> expenses, List<MoneyOperation> payments)
        {
            if (expenses.Sum(e => e.Amount.Value) != payments.Sum(p => p.Amount.Value))
                throw new ArgumentException();
        }

        private static bool HaveNull(IEnumerable<MoneyOperation> operations) => operations.Any(o => o == null);

        private static bool HaveZeroAmount(IEnumerable<MoneyOperation> operations) =>
            operations.Any(o => o.Amount.Value == 0);

        private static bool HaveDuplicatePersons(IEnumerable<MoneyOperation> operations) =>
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