using System;
using NUnit.Framework;

namespace Splid.Domain.Main.Tests.Entities.Groups.GroupTests
{
    [TestFixture]
    public class ChangeGroupExpense : BaseTest
    {
        [Test]
        public void ChangeGroupExpense_NullInput_ThrowArgumentNullException()
        {
            var groupExpenseId = Guid.NewGuid();
            var group = New().Group()
                .AddGroupExpense(groupExpenseId)
                .Build();

            Assert.Throws<ArgumentNullException>(() => group.ChangeGroupExpense(groupExpenseId, null));
        }

        [Test]
        public void ChangeGroupExpense_Unknown_ThrowArgumentException()
        {
            var group = New().Group().Build();
            var groupExpenseInput = New().GroupExpenseInput().Build();
            var unknownGroupExpenseId = Guid.NewGuid();

            Assert.Throws<ArgumentException>(() => group.ChangeGroupExpense(unknownGroupExpenseId, groupExpenseInput));
        }

        [Test]
        public void ChangeGroupExpense_UnknownPaymentPerson_ThrowArgumentException()
        {
            var groupExpenseId = Guid.NewGuid();
            var paymentPersonId = Guid.NewGuid();
            var expensePersonId = Guid.NewGuid();
            var group = New().Group()
                .AddGroupExpense(groupExpenseId, paymentPersonId, expensePersonId, 100)
                .Build();

            var unknowPaymentPersonId = Guid.NewGuid();
            var groupExpenseInput = New().GroupExpenseInput()
                .With(unknowPaymentPersonId, expensePersonId, 100)
                .Build();

            Assert.Throws<ArgumentException>(() => group.ChangeGroupExpense(groupExpenseId, groupExpenseInput));
        }

        [Test]
        public void ChangeGroupExpense_UnknowExpensePerson_ThrowArgumentException()
        {
            var groupExpenseId = Guid.NewGuid();
            var paymentPersonId = Guid.NewGuid();
            var expensePersonId = Guid.NewGuid();
            var group = New().Group()
                .AddGroupExpense(groupExpenseId, paymentPersonId, expensePersonId, 100)
                .Build();

            var unknowExpensePersonId = Guid.NewGuid();
            var groupExpenseInput = New().GroupExpenseInput()
                .With(paymentPersonId, unknowExpensePersonId, 100)
                .Build();

            Assert.Throws<ArgumentException>(() => group.ChangeGroupExpense(groupExpenseId, groupExpenseInput));
        }

        [Test]
        public void ChangeGroupExpense_ValidArguments_DoesNotThrow()
        {
            var groupExpenseId = Guid.NewGuid();
            var paymentPersonId = Guid.NewGuid();
            var expensePersonId = Guid.NewGuid();
            var group = New().Group()
                .AddGroupExpense(groupExpenseId, paymentPersonId, expensePersonId, 100)
                .Build();
            
            var groupExpenseInput = New().GroupExpenseInput()
                .With(paymentPersonId, expensePersonId, 1000)
                .Build();

            Assert.DoesNotThrow(() => group.ChangeGroupExpense(groupExpenseId, groupExpenseInput));
        }
    }
}
