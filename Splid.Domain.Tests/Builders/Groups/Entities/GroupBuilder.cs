using Splid.Domain.Main.Entities.Groups;
using Splid.Domain.Main.Values;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Splid.Domain.Tests.Builders.Groups.Entities
{
    public class GroupBuilder : IBuilder<Group>
    {
        private Guid _id;
        private string _name;
        private List<Person> _persons;
        private List<Payment> _payments;
        private List<Expense> _expenses;

        public GroupBuilder()
        { }

        public GroupBuilder AddExpense(Guid expenseId)
        {
            return this.AddExpense(expenseId, Guid.NewGuid(), Guid.NewGuid(), 100);
        }

        public GroupBuilder AddExpense(Guid expenseId, Guid expenseByPersonId, Guid expenseForPersonId, decimal amount)
        {
            if (_expenses == null)
                _expenses = new List<Expense>();

            if (_persons == null)
                _persons = new List<Person>();

            if (!_persons.Any(p => p.Id == expenseByPersonId))
                _persons.Add(new Person(expenseByPersonId, $"test_person_1"));

            if (!_persons.Any(p => p.Id == expenseForPersonId))
                _persons.Add(new Person(expenseForPersonId, $"test_person_2"));

            var expensesBy = new List<PersonMoney>() { new PersonMoney(expenseByPersonId, new Money(amount)) };
            var expensesFor = new List<PersonMoney>() { new PersonMoney(expenseForPersonId, new Money(amount)) };

            _expenses.Add(new Expense(expenseId, "test_expense", expensesBy, expensesFor, DateTimeOffset.Now, DateTimeOffset.Now));

            return this;
        }

        public GroupBuilder SetPersons(params Guid[] personsIds)
        {
            _persons = new List<Person>();

            for (int i = 0; i < personsIds.Length; i++)
                _persons.Add(new Person(personsIds[i], $"test_person_{i}"));

            return this;
        }

        public Group Build()
        {
            return new Group
                (
                    _id != default(Guid) ? _id : Guid.NewGuid(),
                    !String.IsNullOrWhiteSpace(_name) ? _name : "test_name",
                    _persons ?? new List<Person>(),
                    _payments ?? new List<Payment>(),
                    _expenses ?? new List<Expense>()
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
                .Select(builder => builder.Build())
                .ToList();
        }
    }
}
