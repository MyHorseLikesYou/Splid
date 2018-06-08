using NUnit.Framework;
using Splid.Domain.Main.Entities.Groups;
using Splid.Domain.Main.Values;
using System;
using System.Collections.Generic;

namespace Splid.Domain.Tests.Entities.Groups.GroupTests
{
    [TestFixture]
    public class Group_Construct
    {
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void Construct_InvalidName_ThrowArgumentException(string groupName)
        {
            Assert.Throws<ArgumentException>(() => new Group(Guid.NewGuid(), groupName, new List<Person>(), new List<Payment>(), new List<Expense>()));
        }


        private static IEnumerable<TestCaseData> ConstructGroup_Arguments_NullPersonsOrPaymentsOrExpenses =>
            new[]
            {
                new TestCaseData(null, new List<Payment>(), new List<Expense>()),
                new TestCaseData(new List<Person>(), null, new List<Expense>()),
                new TestCaseData(new List<Person>(), new List<Payment>(), null)
            };

        [Test, TestCaseSource(nameof(ConstructGroup_Arguments_NullPersonsOrPaymentsOrExpenses))]
        public void Construct_NullPersonsOrPaymentsOrExpenses_ThrowArgumentNullException(IEnumerable<Person> persons, IEnumerable<Payment> payments, IEnumerable<Expense> expenses)
        {
            Assert.Throws<ArgumentNullException>(() => new Group(Guid.NewGuid(), "test_group", persons, payments, expenses));
        }


        private static IEnumerable<TestCaseData> Construct_PaymentsHaveUnknownPerson_ArgumentsFactory()
        {
            var persons = new[]
            {
                new Person(Guid.NewGuid(), "test_person_1"),
                new Person(Guid.NewGuid(), "test_person_2")
            };

            yield return new TestCaseData(Guid.NewGuid(), persons[0].Id, persons);
            yield return new TestCaseData(persons[0].Id, Guid.NewGuid(), persons);
        }
        
        [Test, TestCaseSource(nameof(Construct_PaymentsHaveUnknownPerson_ArgumentsFactory))]
        public void Construct_PaymentsHaveUnknownPerson_ThrowArgumentException(Guid personFromId, Guid personToId, Person[] persons)
        {
            var payments = new List<Payment>()
            {
                new Payment
                (
                    id: Guid.NewGuid(),
                    personFromId: personFromId,
                    personToId: personToId,
                    amount: new Money(100),
                    date: DateTimeOffset.Now,
                    createdAt: DateTimeOffset.Now
                )
            };

            Assert.Throws<ArgumentException>(() => new Group(Guid.NewGuid(), "test_group", persons, payments, new List<Expense>()));
        }

        private static IEnumerable<TestCaseData> Construct_ExpensesHaveUnknownPerson_ArgumentsFactory()
        {
            var persons = new[]
            {
                new Person(Guid.NewGuid(), "test_person_1"),
                new Person(Guid.NewGuid(), "test_person_2")
            };

            yield return new TestCaseData(Guid.NewGuid(), persons[0].Id, persons);
            yield return new TestCaseData(persons[0].Id, Guid.NewGuid(), persons);
        }

        [Test, TestCaseSource(nameof(Construct_ExpensesHaveUnknownPerson_ArgumentsFactory))]
        public void Construct_ExpensesHaveUnknownPerson_ThrowArgumentException(Guid personById, Guid personForId, Person[] persons)
        {
            var expenseBy = new PersonMoney(Guid.NewGuid(), new Money(100));
            var expenseFor = new PersonMoney(persons[0].Id, new Money(100));

            var expenses = new List<Expense>()
            {
                new Expense
                (
                    id: Guid.NewGuid(),
                    title: "test_expense",
                    expensesBy: new List<PersonMoney>() { expenseBy },
                    expensesFor: new List<PersonMoney>() { expenseFor },
                    date: DateTimeOffset.Now,
                    createdAt: DateTimeOffset.Now
                )
            };

            Assert.Throws<ArgumentException>(() => new Group(Guid.NewGuid(), "test_group", persons, new List<Payment>(), expenses));
        }

        [Test]
        public void Construct_PersonsHaveSameName_ThrowArgumentException()
        {
            var persons = new List<Person>()
            {
                new Person(Guid.NewGuid(), "test_name"),
                new Person(Guid.NewGuid(), "test_name"),
            };

            Assert.Throws<ArgumentException>(() => new Group(Guid.NewGuid(), "test_group", persons, new List<Payment>(), new List<Expense>()));
        }
    }
}
