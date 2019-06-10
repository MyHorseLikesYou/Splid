using System;
using System.Collections.Generic;
using Splid.Domain.Main.Models;
using Splid.Domain.Main.Tests.Builders.Groups.Entities;
using Splid.Domain.Main.Values;

namespace Splid.Domain.Main.Tests.Builders.Groups.Inputs
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
            _expenseInput.Payments = new List<MoneyOperation>() { new MoneyOperation(paymentPersonId, new Money(amount)) };
            _expenseInput.Expenses = new List<MoneyOperation>() { new MoneyOperation(expensePersonId, new Money(amount)) };

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
            _expenseInput.Payments = new List<MoneyOperation>();
            return this;
        }

        public GroupExpenseInputBuilder HasPayment(decimal amount)
        {
            AddPayment(Create(Guid.NewGuid(), amount));
            return this;
        }

        public GroupExpenseInputBuilder WithPayment(Guid personId, decimal amount)
        {
            AddPayment(Create(personId, amount));
            return this;
        }

        public GroupExpenseInputBuilder WithPayment(MoneyOperation payment)
        {
            AddPayment(Create(personId, amount));
            return this;
        }

        public GroupExpenseInputBuilder WithNullExpenses()
        {
            _expenseInput.Expenses = null;
            return this;
        }

        public GroupExpenseInputBuilder WithEmptyExpenses()
        {
            _expenseInput.Expenses = new List<MoneyOperation>();
            return this;
        }

        private void AddPayment(MoneyOperation payment)
        {
            if (ArePaymentsDefaultValue())
                _expenseInput.Payments = new List<MoneyOperation>();

            _expenseInput.Payments.Add(payment);
        }

        private bool ArePaymentsDefaultValue()
        {
            return _expenseInput.Payments == GroupExpenseBuilder.DefaultPayments;
        }

        public GroupExpenseInputBuilder WithExpense(decimal amount)
        {
            AddExpense(Create(Guid.NewGuid(), amount));
            return this;
        }
        
        public GroupExpenseInputBuilder WithExpense(Money money)
        {
            AddExpense(Create(Guid.NewGuid(), amount));
            return this;
        }

        public GroupExpenseInputBuilder HasExpense(Guid personId, decimal amount)
        {
            AddExpense(Create(personId, amount));
            return this;
        }

        public GroupExpenseInputBuilder HasNullPayment()
        {
            AddPayment(null);
            return this;
        }

        public GroupExpenseInputBuilder HasNullExpense()
        {
            AddExpense(null);
            return this;
        }

        private void AddExpense(MoneyOperation expense)
        {
            if (AreExpenseDefaultValue())
                _expenseInput.Expenses = new List<MoneyOperation>();

            _expenseInput.Expenses.Add(expense);
        }

        private bool AreExpenseDefaultValue()
        {
            return _expenseInput.Expenses == GroupExpenseBuilder.DefaultExpenses;
        }

        public GroupExpenseInput Please()
        {
            return _expenseInput;
        }

        private static MoneyOperation Create(Guid personId, decimal amount)
        {
            return new MoneyOperation(personId, new Money(amount));
        }
    }
}
