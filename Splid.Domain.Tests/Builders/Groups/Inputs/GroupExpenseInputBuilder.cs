using Splid.Domain.Main.Values;
using Splid.Domain.Models.Groups;
using Splid.Domain.Tests.Builders.Groups.Entities;
using System;
using System.Collections.Generic;

namespace Splid.Domain.Tests.Builders.Groups.Inputs
{
    public class GroupExpenseInputBuilder : IBuilder<GroupExpenseInput>
    {
        private GroupExpenseInput _expenseInput;

        public GroupExpenseInputBuilder()
        {
            _expenseInput = new GroupExpenseInput()
            {
                Title = GroupExpenseBuilder.DefaultTitle,
                Payments = GroupExpenseBuilder.DefaultPayments,
                Expenses = GroupExpenseBuilder.DefaultExpenses,
                Date = GroupExpenseBuilder.DefaultDate,
            };
        }

        public GroupExpenseInputBuilder With(Guid paymentPersonId, Guid expensePersonId, decimal amount)
        {
            _expenseInput.Payments = new List<PersonMoneyOperation>() { new PersonMoneyOperation(paymentPersonId, new Money(amount)) };
            _expenseInput.Expenses = new List<PersonMoneyOperation>() { new PersonMoneyOperation(expensePersonId, new Money(amount)) };

            return this;
        }

        public GroupExpenseInputBuilder WithTitle(string title)
        {
            _expenseInput.Title = title;
            return this;
        }

        public GroupExpenseInputBuilder WithFutureDate()
        {
            _expenseInput.Date = DateTimeOffset.Now.AddDays(1);
            return this;
        }

        public GroupExpenseInputBuilder WithNullPayments()
        {
            _expenseInput.Payments = null;
            return this;
        }

        public GroupExpenseInputBuilder WithEmptyPayments()
        {
            _expenseInput.Payments = new List<PersonMoneyOperation>();
            return this;
        }

        public GroupExpenseInputBuilder HasPayment(decimal amount)
        {
            this.AddPayment(Create(Guid.NewGuid(), amount));
            return this;
        }

        public GroupExpenseInputBuilder HasPayment(Guid personId, decimal amount)
        {
            this.AddPayment(Create(personId, amount));
            return this;
        }

        public GroupExpenseInputBuilder WithNullExpenses()
        {
            _expenseInput.Expenses = null;
            return this;
        }

        public GroupExpenseInputBuilder WithEmptyExpenses()
        {
            _expenseInput.Expenses = new List<PersonMoneyOperation>();
            return this;
        }

        private void AddPayment(PersonMoneyOperation payment)
        {
            if (ArePaymentsDefaultValue())
                _expenseInput.Payments = new List<PersonMoneyOperation>();

            _expenseInput.Payments.Add(payment);
        }

        private bool ArePaymentsDefaultValue()
        {
            return _expenseInput.Payments == GroupExpenseBuilder.DefaultPayments;
        }

        public GroupExpenseInputBuilder HasExpense(decimal amount)
        {
            this.AddExpense(Create(Guid.NewGuid(), amount));
            return this;
        }

        public GroupExpenseInputBuilder HasExpense(Guid personId, decimal amount)
        {
            this.AddExpense(Create(personId, amount));
            return this;
        }

        public GroupExpenseInputBuilder HasNullPayment()
        {
            this.AddPayment(null);
            return this;
        }

        public GroupExpenseInputBuilder HasNullExpense()
        {
            this.AddExpense(null);
            return this;
        }

        private void AddExpense(PersonMoneyOperation expense)
        {
            if (AreExpenseDefaultValue())
                _expenseInput.Expenses = new List<PersonMoneyOperation>();

            _expenseInput.Expenses.Add(expense);
        }

        private bool AreExpenseDefaultValue()
        {
            return _expenseInput.Expenses == GroupExpenseBuilder.DefaultExpenses;
        }

        public GroupExpenseInput Build()
        {
            return _expenseInput;
        }

        private static PersonMoneyOperation Create(Guid personId, decimal amount)
        {
            return new PersonMoneyOperation(personId, new Money(amount));
        }
    }
}
