using System;
using System.Linq;
using NUnit.Framework;
using Splid.Domain.Main.Tests.Builders.Groups.Entities;

namespace Splid.Domain.Main.Tests.Services.GroupExpenseServiceTests
{
    [TestFixture]
    public class CreateGroupExpense : BaseTest
    {
        [Test]
        public void AddGroupExpense_NullInput_ThrowArgumentNullException()
        {
            var group = New().Group().Build();

            Assert.Throws<ArgumentNullException>(() => group.AddGroupExpense(Guid.NewGuid(), null));
        }

        [Test]
        public void AddGroupExpense_UnknownPaymentPerson_ThrowArgumentException()
        {
            var expensePersonId = Guid.NewGuid();
            var group = New().Group().HavePersonsWithIds(expensePersonId).Build();

            var unknownPaymentPersonId = Guid.NewGuid();
            var groupExpenseInput = New().GroupExpenseInput().With(unknownPaymentPersonId, expensePersonId, 100).Build();

            Assert.Throws<ArgumentException>(() => group.AddGroupExpense(Guid.NewGuid(), groupExpenseInput));
        }

        [Test]
        public void AddGroupExpense_UnknownExpensePerson_ThrowArgumentException()
        {
            var paymentPersonId = Guid.NewGuid();
            var group = GroupBuilder.New()
                .HavePersonsWithIds(paymentPersonId)
                .Build();

            var unknownExpensePersonId = Guid.NewGuid();
            var groupExpenseInput = New().GroupExpenseInput()
                .With(paymentPersonId, unknownExpensePersonId, 100)
                .Build();

            Assert.Throws<ArgumentException>(() => group.AddGroupExpense(Guid.NewGuid(), groupExpenseInput));
        }

        [Test]
        public void AddGroupExpense_ValidArguments_GroupHasExpense()
        {
            var paymentPersonId = Guid.NewGuid();
            var expensePersonId = Guid.NewGuid();

            var group = New().Group()
                .HavePersonsWithIds(paymentPersonId, expensePersonId)
                .Build();

            var groupExpenseId = Guid.NewGuid();
            var groupExpenseInput = New().GroupExpenseInput()
                .With(paymentPersonId, expensePersonId, 1000)
                .Build();

            group.AddGroupExpense(groupExpenseId, groupExpenseInput);

            Assert.That(group.Expenses.Any(e => e.Id == groupExpenseId));
        }
    }
}
