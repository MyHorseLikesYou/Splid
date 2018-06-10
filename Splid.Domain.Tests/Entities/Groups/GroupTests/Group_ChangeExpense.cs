using NUnit.Framework;
using Splid.Domain.Tests.Builders;
using Splid.Domain.Tests.Builders.Groups.Entities;
using Splid.Domain.Tests.Builders.Groups.Inputs;
using System;

namespace Splid.Domain.Tests.Entities.Groups.GroupTests
{
    [TestFixture]
    public class Group_ChangeExpense
    {
        [Test]
        public void ChangeExpense_NullExpenseInput_ThrowArgumentNullException()
        {
            var expenseId = Guid.NewGuid();
            var group = GroupBuilder.New()
                .AddExpense(expenseId)
                .Build();

            Assert.Throws<ArgumentNullException>(() => group.ChangeExpense(expenseId, null));
        }

        [Test]
        public void ChangeExpense_UnknownExpense_ThrowArgumentException()
        {
            var group = GroupBuilder.New().Build();
            var expenseInput = New().GroupExpenseInput().Build();
            var unknownExpenseId = Guid.NewGuid();

            Assert.Throws<ArgumentException>(() => group.ChangeExpense(unknownExpenseId, expenseInput));
        }

        [Test]
        public void ChangeExpense_UnknownExpenseByPerson_ThrowArgumentException()
        {
            var expenseId = Guid.NewGuid();
            var expenseByPersonId = Guid.NewGuid();
            var expenseForPersonId = Guid.NewGuid();
            var group = GroupBuilder.New()
                .AddExpense(expenseId, expenseByPersonId, expenseForPersonId, 100)
                .Build();

            var unknowExpenseByPersonId = Guid.NewGuid();
            var expenseInput = New().GroupExpenseInput()
                .Set(unknowExpenseByPersonId, expenseForPersonId, 100)
                .Build();

            Assert.Throws<ArgumentException>(() => group.ChangeExpense(expenseId, expenseInput));
        }

        [Test]
        public void ChangeExpense_UnknowExpenseForPerson_ThrowArgumentException()
        {
            var expenseId = Guid.NewGuid();
            var expenseByPersonId = Guid.NewGuid();
            var expenseForPersonId = Guid.NewGuid();
            var group = GroupBuilder.New()
                .AddExpense(expenseId, expenseByPersonId, expenseForPersonId, 100)
                .Build();

            var unknowExpenseForPersonId = Guid.NewGuid();
            var expenseInput = New().GroupExpenseInput()
                .Set(expenseByPersonId, unknowExpenseForPersonId, 100)
                .Build();

            Assert.Throws<ArgumentException>(() => group.ChangeExpense(expenseId, expenseInput));
        }

        [Test]
        public void ChangeExpense_ValidArguments_DoesNotThrow()
        {
            var expenseId = Guid.NewGuid();
            var expenseByPersonId = Guid.NewGuid();
            var expenseForPersonId = Guid.NewGuid();
            var group = GroupBuilder.New()
                .AddExpense(expenseId, expenseByPersonId, expenseForPersonId, 100)
                .Build();
            
            var expenseInput = New().GroupExpenseInput()
                .Set(expenseByPersonId, expenseForPersonId, 1000)
                .Build();

            Assert.DoesNotThrow(() => group.ChangeExpense(expenseId, expenseInput));
        }

        private BuilderFactory New()
        {
            return new BuilderFactory();
        }
    }
}
