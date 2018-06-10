using NUnit.Framework;
using Splid.Domain.Tests.Builders;
using Splid.Domain.Tests.Builders.Groups.Entities;
using Splid.Domain.Tests.Builders.Groups.Inputs;
using System;
using System.Linq;

namespace Splid.Domain.Tests.Entities.Groups.GroupTests
{
    [TestFixture]
    public class Group_AddExpense
    {
        [Test]
        public void AddExpense_NullExpenseInput_ThrowArgumentNullException()
        {
            var group = GroupBuilder.New().Build();

            Assert.Throws<ArgumentNullException>(() => group.AddExpense(Guid.NewGuid(), null));
        }

        [Test]
        public void AddExpense_UnknownExpenseByPerson_ThrowArgumentException()
        {
            var expenseForPersonId = Guid.NewGuid();
            var group = GroupBuilder.New()
                .HavePersonsWithIds(expenseForPersonId)
                .Build();

            var unknownExpenseByPersonId = Guid.NewGuid();
            var expenseInput = New().GroupExpenseInput()
                .Set(unknownExpenseByPersonId, expenseForPersonId, 100)
                .Build();

            Assert.Throws<ArgumentException>(() => group.AddExpense(Guid.NewGuid(), expenseInput));
        }

        [Test]
        public void AddExpense_UnknownExpenseForPerson_ThrowArgumentException()
        {
            var expenseByPersonId = Guid.NewGuid();
            var group = GroupBuilder.New()
                .HavePersonsWithIds(expenseByPersonId)
                .Build();

            var unknownExpenseForPersonId = Guid.NewGuid();
            var expenseInput = New().GroupExpenseInput()
                .Set(expenseByPersonId, unknownExpenseForPersonId, 100)
                .Build();

            Assert.Throws<ArgumentException>(() => group.AddExpense(Guid.NewGuid(), expenseInput));
        }

        [Test]
        public void AddExpense_ValidArguments_GroupHasExpense()
        {
            var expenseByPersonId = Guid.NewGuid();
            var expenseForPersonId = Guid.NewGuid();

            var group = GroupBuilder.New()
                .HavePersonsWithIds(expenseByPersonId, expenseForPersonId)
                .Build();

            var expenseId = Guid.NewGuid();
            var expenseInput = New().GroupExpenseInput()
                .Set(expenseByPersonId, expenseForPersonId, 1000)
                .Build();

            group.AddExpense(expenseId, expenseInput);

            Assert.That(group.Expenses.Any(e => e.Id == expenseId));
        }

        private BuilderFactory New()
        {
            return new BuilderFactory();
        }
    }
}
