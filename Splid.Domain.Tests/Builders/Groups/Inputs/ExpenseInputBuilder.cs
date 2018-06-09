using Splid.Domain.Main.Values;
using Splid.Domain.Models.Groups;
using System;
using System.Collections.Generic;

namespace Splid.Domain.Tests.Builders.Groups.Inputs
{
    public class ExpenseInputBuilder : IBuilder<ExpenseInput>
    {
        private ExpenseInput _expenseInput;

        public ExpenseInputBuilder()
        {
            _expenseInput = new ExpenseInput();
        }

        public ExpenseInputBuilder Set(Guid expenseByPersonId, Guid expenseForPersonId, decimal amount)
        {
            if (_expenseInput == null)
                _expenseInput = new ExpenseInput();

            _expenseInput.By = new List<PersonMoney>() { new PersonMoney(expenseByPersonId, new Money(amount)) };
            _expenseInput.For = new List<PersonMoney>() { new PersonMoney(expenseForPersonId, new Money(amount)) };

            return this;
        }

        public ExpenseInput Build()
        {
            if (_expenseInput.Date == default(DateTimeOffset))
                _expenseInput.Date = DateTimeOffset.Now;

            if (String.IsNullOrWhiteSpace(_expenseInput.Title))
                _expenseInput.Title = "test_expense";

            if (_expenseInput.For == null)
                _expenseInput.For = new List<PersonMoney>();

            if (_expenseInput.By == null)
                _expenseInput.By = new List<PersonMoney>();

            return _expenseInput;
        }

        public static ExpenseInputBuilder New()
        {
            return new ExpenseInputBuilder();
        }
    }
}
