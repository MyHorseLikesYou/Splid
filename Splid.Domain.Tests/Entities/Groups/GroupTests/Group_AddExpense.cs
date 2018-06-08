using NUnit.Framework;
using Splid.Domain.Main.Entities.Groups;
using Splid.Domain.Main.Values;
using Splid.Domain.Models.Groups;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Splid.Domain.Tests.Entities.Groups.GroupTests
{
    [TestFixture]
    public class Group_AddExpense
    {
        [Test]
        public void AddExpense_NullExpenseInput_ThrowArgumentNullException()
        {
            var group = new Group(Guid.NewGuid(), "test_group", new List<Person>(), new List<Payment>(), new List<Expense>());

            Assert.Throws<ArgumentNullException>(() => group.AddExpense(Guid.NewGuid(), null));
        }

        private static IEnumerable<TestCaseData> AddExpense_HaveUnknownPerson_ArgumentsFactory()
        {
            var persons = new[]
            {
                new Person(Guid.NewGuid(), "test_person_1"),
                new Person(Guid.NewGuid(), "test_person_2")
            };

            return new[]
            {
                new TestCaseData(Guid.NewGuid(), persons[0].Id, persons),
                new TestCaseData(persons[0].Id, Guid.NewGuid(), persons)
            };
        }

        [Test, TestCaseSource(nameof(AddExpense_HaveUnknownPerson_ArgumentsFactory))]
        public void AddExpense_HaveUnknowPerson_ThrowArgumentException(Guid expenseByPersonId, Guid expenseForPersonId, Person[] persons)
        {
            var group = new Group(Guid.NewGuid(), "test_group", persons, new List<Payment>(), new List<Expense>());
            var expenseInput = new ExpenseInput()
            {
                By = new List<PersonMoney>() { new PersonMoney(expenseByPersonId, new Money(100)) },
                For = new List<PersonMoney>() { new PersonMoney(expenseForPersonId, new Money(100)) },
                Title = "test_title",
                Date = DateTimeOffset.Now,
            };

            Assert.Throws<ArgumentException>(() => group.AddExpense(Guid.NewGuid(), expenseInput));
        }

        [Test]
        public void AddExpense_ValidArguments_GroupHasExpense()
        {
            var expenseByPerson = new Person(Guid.NewGuid(), "test_name_1");
            var expenseForPerson = new Person(Guid.NewGuid(), "test_name_2");
            var group = new Group(Guid.NewGuid(), "test_group", new List<Person>() { expenseByPerson, expenseForPerson }, new List<Payment>(), new List<Expense>());

            var expenseId = Guid.NewGuid();
            var expenseInput = new ExpenseInput()
            {
                By = new List<PersonMoney>() { new PersonMoney(expenseByPerson.Id, new Money(100)) },
                For = new List<PersonMoney>() { new PersonMoney(expenseForPerson.Id, new Money(100)) },
                Title = "test_title",
                Date = DateTimeOffset.Now,
            };

            group.AddExpense(expenseId, expenseInput);

            Assert.That(group.Expenses.Any(e => e.Id == expenseId));
        }
    }
}
