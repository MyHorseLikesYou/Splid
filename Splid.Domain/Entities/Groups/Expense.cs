using MyApp.Core.Domain;
using Splid.Domain.Main.Values;
using System;
using System.Collections.Generic;

namespace Splid.Domain.Main.Entities.Groups
{
    public class Expense : Entity
    {
        //private List<ExpenseBy> _expensesBy;
        //private List<ExpenseFor> _expensesFor;

        private string _title;
        public string Title
        {
            get => _title;
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                    throw new ArgumentException(nameof(Expense.Title), "Название траты не может быть пустым.");

                _title = value;
            }
        }

        private DateTime _date;
        public DateTime Date
        {
            get => _date;
            set => _date = value.Date;
        }

        public Expense(Guid id, string title,/* IEnumerable<ExpenseBy> expensesBy, IEnumerable<ExpenseFor> expensesFor, */DateTime date)
            : base(id)
        {
            //this.Title = title;
            //_expensesBy = expensesBy?.ToList() ?? throw new ArgumentNullException(nameof(expensesBy));
            //_expensesFor = expensesFor?.ToList() ?? throw new ArgumentNullException(nameof(expensesFor));
            //this.Date = date;
        }

        public IEnumerable<Guid> GetPersonsExpensesBy()
        {
            //return _expensesBy
            //    .Select(e => e.PersonId)
            //    .ToList();

            throw new Exception();
        }

        public IEnumerable<Guid> GetPersonsExpensesFor()
        {
            //return _expensesFor
            //    .Select(e => e.PersonId)
            //    .ToList();

            throw new Exception();
        }

        public void SetExpensesFor(IDictionary<Guid, Money> expensesFor)
        {
            if (expensesFor == null)
                throw new ArgumentNullException(nameof(expensesFor));

            //_expensesFor.Clear();
            //_expensesFor.AddRange(ExpenseFor.Create(expensesFor));
        }

        public void SetExpensesBy(IDictionary<Guid, Money> expensesBy)
        {
            if (expensesBy == null)
                throw new ArgumentNullException(nameof(expensesBy));

            //_expensesBy.Clear();
            //_expensesBy.AddRange(ExpenseBy.Create(expensesBy));
        }
    }
}
