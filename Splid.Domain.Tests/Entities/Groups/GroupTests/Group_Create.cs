using NUnit.Framework;
using NUnit.Framework.Internal;
using Splid.Domain.Main.Entities.Groups;
using System;
using System.Collections.Generic;

namespace Splid.Domain.Tests.Entities.Groups.GroupTests
{
    [TestFixture]
    public class Group_Create
    {
        public static IEnumerable<TestCaseData> CreateGroup_InvalidNames
        {
            get
            {
                yield return new TestCaseData(null, new List<Person>(), new List<Payment>(), new List<Expense>());
                yield return new TestCaseData("", new List<Person>(), new List<Payment>(), new List<Expense>());
                yield return new TestCaseData(" ", new List<Person>(), new List<Payment>(), new List<Expense>());
            }
        }

        [Test, TestCaseSource(nameof(CreateGroup_InvalidNames))]
        public void InvalidName_ThrowArgumentException(string groupName, IEnumerable<Person> persons, IEnumerable<Payment> payments, IEnumerable<Expense> expenses)
        {
            Assert.Throws<ArgumentException>(() => new Group(Guid.NewGuid(), groupName, persons, payments, expenses));
        }

        public static IEnumerable<TestCaseData> CreateGroup_InvalidPersonsOrPaymentsOrExpenses
        {
            get
            {
                yield return new TestCaseData("test_name", null, new List<Payment>(), new List<Expense>());
                yield return new TestCaseData("test_name", new List<Person>(), null, new List<Expense>());
                yield return new TestCaseData("test_name", new List<Person>(), new List<Payment>(), null);
            }
        }

        [Test, TestCaseSource(nameof(CreateGroup_InvalidPersonsOrPaymentsOrExpenses))]
        public void NullPersonsOrPaymentsOrExpenses_ThrowArgumentNullException(string groupName, IEnumerable<Person> persons, IEnumerable<Payment> payments, IEnumerable<Expense> expenses)
        {
            Assert.Throws<ArgumentNullException>(() => new Group(Guid.NewGuid(), groupName, persons, payments, expenses));
        }
    }
}
