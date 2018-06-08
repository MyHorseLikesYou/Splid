using MyApp.Core.Domain;
using MyApp.Core.Extensions;
using Splid.Domain.Main.Values;
using Splid.Domain.Models.Groups;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Splid.Domain.Main.Entities.Groups
{
    public class Expense : Entity
    {
        private string _title;
        private List<PersonMoney> _expensesBy;
        private List<PersonMoney> _expensesFor;
        private DateTimeOffset _date;
        private Guid expenseId;
        private ExpenseInput expenseInput;

        public Expense(Guid id, string title, IEnumerable<PersonMoney> expensesBy, IEnumerable<PersonMoney> expensesFor, DateTimeOffset date, DateTimeOffset createdAt)
            : base(id)
        {
            ValidateArgumentForTitle(title);
            ValidateArgumentForDate(date);
            ValidateArgumentForExpensesBy(expensesBy);
            ValidateArgumentForExpensesFor(expensesBy);

            _title = title;
            _expensesBy = expensesBy.ToList();
            _expensesFor = expensesFor.ToList();
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

        public IReadOnlyCollection<PersonMoney> ExpensesFor => _expensesFor;

        public IReadOnlyCollection<PersonMoney> ExpensesBy => _expensesBy;

        public void SetExpensesFor(IEnumerable<PersonMoney> expensesFor)
        {
            ValidateArgumentForExpensesFor(expensesFor);
            _expensesFor = expensesFor.ToList();
        }

        public void SetExpensesBy(IEnumerable<PersonMoney> expensesBy)
        {
            ValidateArgumentForExpensesBy(expensesBy);
            _expensesBy = expensesBy.ToList();
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

        private static void ValidateArgumentForExpensesFor(IEnumerable<PersonMoney> expensesBy)
        {
            if (expensesBy == null)
                throw new ArgumentNullException(nameof(expensesBy));
        }

        private static void ValidateArgumentForExpensesBy(IEnumerable<PersonMoney> expensesBy)
        {
            if (expensesBy == null)
                throw new ArgumentNullException(nameof(expensesBy));
        }

        internal void Change(ExpenseInput expenseInput)
        {
            throw new NotImplementedException();
        }

        public static Expense Create(Guid id, ExpenseInput expenseInput)
        {
            if (expenseInput == null)
                throw new ArgumentNullException();

            return new Expense(id, expenseInput.Title, expenseInput.By, expenseInput.For, expenseInput.Date, DateTimeOffset.Now);
        }
    }
}
