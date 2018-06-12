using Splid.Domain.Main.Entities.Groups;
using Splid.Domain.Main.Values;
using System;
using System.Collections.Generic;

namespace Splid.Domain.Tests.Builders.Groups.Entities
{
    public class GroupExpenseBuilder : IBuilder<GroupExpense>
    {       
        private static List<PersonMoneyOperation> _defaultPayments = new List<PersonMoneyOperation>() { new PersonMoneyOperation(Guid.NewGuid(), new Money(100)) };
        private static List<PersonMoneyOperation> _defaultExpenses = new List<PersonMoneyOperation>() { new PersonMoneyOperation(Guid.NewGuid(), new Money(100)) };

        public static string DefaultTitle => "test_group_expense";
        public static List<PersonMoneyOperation> DefaultPayments => _defaultPayments;
        public static List<PersonMoneyOperation> DefaultExpenses => _defaultExpenses;
        public static DateTimeOffset DefaultDate => DateTimeOffset.Now;

        private Guid _id;
        private string _title;
        private List<PersonMoneyOperation> _payments;
        private List<PersonMoneyOperation> _expenses;
        private DateTimeOffset _date;
        private DateTimeOffset _createdAtDate;

        public GroupExpenseBuilder()
        {
            _title = DefaultTitle;
            _payments = _defaultPayments;
            _expenses = _defaultExpenses;
            _date = DefaultDate;
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
            _payments = new List<PersonMoneyOperation>() { new PersonMoneyOperation(paymentPerson.Id, new Money(amount)) };
            _expenses = new List<PersonMoneyOperation>() { new PersonMoneyOperation(expensePerson.Id, new Money(amount)) };

            return this;
        }

        public GroupExpense Build()
        {
            return new GroupExpense(_id, _title, _payments, _expenses, _date, _createdAtDate);
        }
    }
}
