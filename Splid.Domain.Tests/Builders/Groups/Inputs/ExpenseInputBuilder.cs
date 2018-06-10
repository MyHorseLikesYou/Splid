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

            _expenseInput.By = new List<PersonMoneyOperation>() { new PersonMoneyOperation(expenseByPersonId, new Money(amount)) };
            _expenseInput.For = new List<PersonMoneyOperation>() { new PersonMoneyOperation(expenseForPersonId, new Money(amount)) };

            return this;
        }

        public ExpenseInputBuilder WithTitle(string title)
        {
            throw new NotImplementedException();
        }

        public ExpenseInput Build()
        {
            if (_expenseInput.Date == default(DateTimeOffset))
                _expenseInput.Date = DateTimeOffset.Now;

            if (String.IsNullOrWhiteSpace(_expenseInput.Title))
                _expenseInput.Title = "test_expense";

            if (_expenseInput.For == null)
                _expenseInput.For = new List<PersonMoneyOperation>();

            if (_expenseInput.By == null)
                _expenseInput.By = new List<PersonMoneyOperation>();

            return _expenseInput;
        }

        public ExpenseInputBuilder WithFutureDate()
        {
            throw new NotImplementedException();
        }

        internal ExpenseInputBuilder WithNullPayments()
        {
            throw new NotImplementedException();
        }

        internal ExpenseInputBuilder WithExpensesFor(object p)
        {
            throw new NotImplementedException();
        }

        internal ExpenseInputBuilder WithEmptyPayments()
        {
            throw new NotImplementedException();
        }

        internal ExpenseInputBuilder WithNullExpenses()
        {
            throw new NotImplementedException();
        }

        internal ExpenseInputBuilder HaveExpenseBy(Guid personIdThatWillDuplicate, int amount)
        {
            throw new NotImplementedException();
        }

        internal ExpenseInputBuilder HasPayment(int amount)
        {
            throw new NotImplementedException();
        }

        internal ExpenseInputBuilder HasExpense(int amount)
        {
            throw new NotImplementedException();
        }

        internal ExpenseInputBuilder HasPayment(Guid personIdThatWillDuplicate, int v)
        {
            throw new NotImplementedException();
        }

        internal ExpenseInputBuilder WithEmptyExpenses()
        {
            throw new NotImplementedException();
        }

        internal ExpenseInputBuilder HasExpense(Guid personIdThatWillDuplicate, int v)
        {
            throw new NotImplementedException();
        }
    }
}
