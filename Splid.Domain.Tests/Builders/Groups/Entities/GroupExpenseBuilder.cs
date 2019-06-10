using System;
using System.Collections.Generic;
using Splid.Domain.Main.Values;

namespace Splid.Domain.Main.Tests.Builders.Groups.Entities
{
    public class GroupExpenseBuilder : IBuilder<GroupExpense>
    {       
        private static List<MoneyOperation> _defaultPayments = new List<MoneyOperation>() { new MoneyOperation(Guid.NewGuid(), new Money(100)) };
        private static List<MoneyOperation> _defaultExpenses = new List<MoneyOperation>() { new MoneyOperation(Guid.NewGuid(), new Money(100)) };

        public static string DefaultTitle => "test_group_expense";
        public static List<MoneyOperation> DefaultPayments => _defaultPayments;
        public static List<MoneyOperation> DefaultExpenses => _defaultExpenses;
        public static DateTimeOffset DefaultDate => DateTimeOffset.Now;

        private Guid _id;
        private string _title;
        private List<MoneyOperation> _payments;
        private List<MoneyOperation> _expenses;
        private DateTimeOffset _date;
        private DateTimeOffset _createdAtDate;

        public GroupExpenseBuilder()
        {
            _id = Guid.NewGuid();
            _title = DefaultTitle;
            _payments = _defaultPayments;
            _expenses = _defaultExpenses;
            _date = DefaultDate;
            _createdAtDate = DateTimeOffset.Now;
        }

        public GroupExpenseBuilder WithId(Guid id)
        {
            _id = id;
            return this;
        }

        public GroupExpenseBuilder WithFutureDate()
        {
            _date = DateTimeOffset.Now.AddDays(1);
            return this;
        }

        public GroupExpenseBuilder With(Person paymentPerson, Person expensePerson, decimal amount)
        {
            _payments = new List<MoneyOperation>() { new MoneyOperation(paymentPerson.Id, new Money(amount)) };
            _expenses = new List<MoneyOperation>() { new MoneyOperation(expensePerson.Id, new Money(amount)) };

            return this;
        }

        public GroupExpense Please()
        {
            return new GroupExpense(_id, _title, _payments, _expenses, _date, _createdAtDate);
        }
    }
}
