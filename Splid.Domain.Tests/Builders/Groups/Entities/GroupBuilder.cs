using System;
using System.Collections.Generic;
using System.Linq;
using Splid.Domain.Main.Entities;
using Splid.Domain.Main.Values;

namespace Splid.Domain.Main.Tests.Builders.Groups.Entities
{
    public class GroupBuilder : IBuilder<Group>
    {
        private Guid _id;
        private string _name;
        private List<Person> _persons;
        private List<Payment> _payments;
        private List<GroupExpense> _expenses;

        public GroupBuilder AddGroupExpense(Guid expenseId)
        {
            return AddGroupExpense(expenseId, Guid.NewGuid(), Guid.NewGuid(), 100);
        }

        public GroupBuilder AddGroupExpense(Guid expenseId, Guid expenseByPersonId, Guid expenseForPersonId, decimal amount)
        {
            if (_expenses == null)
                _expenses = new List<GroupExpense>();

            if (_persons == null)
                _persons = new List<Person>();

            if (!_persons.Any(p => p.Id == expenseByPersonId))
                _persons.Add(new Person(expenseByPersonId, $"test_person_1"));

            if (!_persons.Any(p => p.Id == expenseForPersonId))
                _persons.Add(new Person(expenseForPersonId, $"test_person_2"));

            var expensesBy = new List<MoneyOperation>() { new MoneyOperation(expenseByPersonId, new Money(amount)) };
            var expensesFor = new List<MoneyOperation>() { new MoneyOperation(expenseForPersonId, new Money(amount)) };

            _expenses.Add(new GroupExpense(expenseId, "test_expense", expensesBy, expensesFor, DateTimeOffset.Now, DateTimeOffset.Now));

            return this;
        }

        public GroupBuilder WithPerson(Person person)
        {
            throw new NotImplementedException();
        }
        
        public GroupBuilder AddPayment(Guid paymentId)
        {
            if (_payments == null)
                _payments = new List<Payment>();

            var payment = new PaymentBuilder().WithId(paymentId).Please();
            _payments.Add(payment);

            if (_persons == null)
                _persons = new List<Person>();

            _persons.Add(new Person(payment.PersonFromId, "kksdf"));
            _persons.Add(new Person(payment.PersonToId, "12kksdf"));

            return this;
        }

        public GroupBuilder AddPayment(Guid paymentId, Guid paymentByPersonId, Guid paymentForPersonId, decimal amount)
        {
            if (_payments == null)
                _payments = new List<Payment>();

            if (_persons == null)
                _persons = new List<Person>();

            if (!_persons.Any(p => p.Id == paymentByPersonId))
                _persons.Add(new Person(paymentByPersonId, "kek"));

            if (!_persons.Any(p => p.Id == paymentForPersonId))
                _persons.Add(new Person(paymentForPersonId, "kek-2"));

            _payments.Add(new PaymentBuilder().WithId(paymentId).With(paymentByPersonId, paymentForPersonId, amount).Please());

            return this;
        }

        public GroupBuilder HavePersonsWithNames(params string[] personsNames)
        {
            _persons = new List<Person>();

            for (int i = 0; i < personsNames.Length; i++)
                _persons.Add(new Person(Guid.NewGuid(), personsNames[i]));

            return this;
        }        

        public GroupBuilder HavePersonsWithIds(params Guid[] personsIds)
        {
            _persons = new List<Person>();

            for (int i = 0; i < personsIds.Length; i++)
                _persons.Add(new Person(personsIds[i], $"test_person_{i}"));

            return this;
        }

        public Group Please()
        {
            return new Group
                (
                    _id != default(Guid) ? _id : Guid.NewGuid(),
                    !String.IsNullOrWhiteSpace(_name) ? _name : "test_name",
                    _persons ?? new List<Person>(),
                    _payments ?? new List<Payment>(),
                    _expenses ?? new List<GroupExpense>()
                );
        }

        public static GroupBuilder New()
        {
            return new GroupBuilder();
        }

        private static IEnumerable<TBuildResult> Build<TBuilder, TBuildResult>(params Action<TBuilder>[] buildersConfigurations)
            where TBuilder : IBuilder<TBuildResult>, new()
        {
            return buildersConfigurations
                .Select(builderConfiguration =>
                {
                    var builder = new TBuilder();
                    builderConfiguration.Invoke(builder);
                    return builder;
                })
                .Select(builder => builder.Please())
                .ToList();
        }

        public GroupBuilder WithId(Guid groupId)
        {
            throw new NotImplementedException();
        }
    }
}
