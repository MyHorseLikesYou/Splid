using MyApp.Core.Domain;
using MyApp.Core.Extensions;
using Splid.Domain.Main.Values;
using Splid.Domain.Models.Groups;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Splid.Domain.Main.Entities.Groups
{
    public class GroupExpense : Entity
    {
        private string _title;
        private List<PersonMoneyOperation> _personPayments;
        private List<PersonMoneyOperation> _personExpenses;
        private DateTimeOffset _date;

        public GroupExpense(Guid id, string title, IEnumerable<PersonMoneyOperation> personsPayments, IEnumerable<PersonMoneyOperation> personsExpenses, DateTimeOffset date, DateTimeOffset createdAt)
            : base(id)
        {
            ValidateArgumentForTitle(title);
            ValidateArgumentForDate(date);
            ValidateArgumentForExpensesBy(personsPayments);
            ValidateArgumentForExpensesFor(personsExpenses);

            _title = title;
            _personPayments = personsPayments.ToList();
            _personExpenses = personsExpenses.ToList();
            _date = date;
        }

        public string Title
        {
            get => _title;
            set
            {
                ValidateArgumentForTitle(value);
                _title = value;
            }
        }

        public DateTimeOffset Date
        {
            get => _date;
            set
            {
                ValidateArgumentForDate(value);
                _date = value.Date;
            }
        }

        public IReadOnlyCollection<PersonMoneyOperation> ExpensesFor => _personExpenses;

        public IReadOnlyCollection<PersonMoneyOperation> ExpensesBy => _personPayments;

        public void Change(GroupExpenseInput expenseInput)
        {
            if (expenseInput == null)
                throw new ArgumentNullException();
        }

        private void SetExpensesFor(IEnumerable<PersonMoneyOperation> expensesFor)
        {
            ValidateArgumentForExpensesFor(expensesFor);
            _personExpenses = expensesFor.ToList();
        }

        private void SetExpensesBy(IEnumerable<PersonMoneyOperation> expensesBy)
        {
            ValidateArgumentForExpensesBy(expensesBy);
            _personPayments = expensesBy.ToList();
        }

        private static void ValidateArgumentForTitle(string title)
        {
            if (String.IsNullOrWhiteSpace(title))
                throw new ArgumentException("Название траты не может быть пустым.");
        }

        private static void ValidateArgumentForDate(DateTimeOffset date)
        {
            if (date.IsInFuture())
                throw new ArgumentException("Дата траты не может быть в будующем.");
        }

        private static void ValidateArgumentForExpensesFor(IEnumerable<PersonMoneyOperation> expensesBy)
        {
            if (expensesBy == null)
                throw new ArgumentNullException(nameof(expensesBy));
        }

        private static void ValidateArgumentForExpensesBy(IEnumerable<PersonMoneyOperation> expensesBy)
        {
            if (expensesBy == null)
                throw new ArgumentNullException(nameof(expensesBy));
        }

        public static GroupExpense Create(Guid id, GroupExpenseInput expenseInput)
        {
            if (expenseInput == null)
                throw new ArgumentNullException();

            return new GroupExpense(id, expenseInput.Title, expenseInput.Payments, expenseInput.Expenses, expenseInput.Date, DateTimeOffset.Now);
        }
    }
}
