using System;
using System.Collections.Generic;
using NUnit.Framework;
using Splid.Domain.Main.Tests.Builders;
using Splid.Domain.Main.Tests.Builders.Groups.Values;
using Splid.Domain.Main.Values;

namespace Splid.Domain.Main.Tests.Entities.Groups.ExpenseTests
{
    [TestFixture]
    public class GroupExpense_Change
    {
        [Test]
        public void ChangeGroupExpense_NullInput_ThrowArgumentNullExeption()
        {
            var groupExpense = Create.GroupExpense.Please();

            Assert.Throws<ArgumentNullException>(() => groupExpense.Change(null));
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void ChangeGroupExpense_InvalidTitle_ThrowArgumentExeption(string title)
        {
            var groupExpense = Create.GroupExpense.Please();
            var groupExpenseInput = Create.GroupExpenseInput.WithTitle(title).Please();

            Assert.Throws<ArgumentException>(() => groupExpense.Change(groupExpenseInput));
        }

        [Test]
        public void ChangeGroupExpense_DateInFuture_ThrowArgumentExeption()
        {
            var groupExpense = Create.GroupExpense.Please();
            var groupExpenseInput = Create.GroupExpenseInput.WithFutureDate().Please();

            Assert.Throws<ArgumentException>(() => groupExpense.Change(groupExpenseInput));
        }

        [Test]
        public void ChangeGroupExpense_NullPayments_ThrowArgumentNullExeption()
        {
            var groupExpense = Create.GroupExpense.Please();
            var groupExpenseInput = Create.GroupExpenseInput.WithNullPayments().Please();

            Assert.Throws<ArgumentNullException>(() => groupExpense.Change(groupExpenseInput));
        }

        [Test]
        public void ChangeGroupExpense_EmptyPayments_ThrowArgumentExeption()
        {
            var groupExpense = Create.GroupExpense.Please();
            var groupExpenseInput = Create.GroupExpenseInput.WithEmptyPayments().Please();

            Assert.Throws<ArgumentException>(() => groupExpense.Change(groupExpenseInput));
        }

        [Test]
        public void ChangeGroupExpense_PaymentsHaveZeroAmountPayment_ThrowArgumentExeption()
        {
            var groupExpense = Create.GroupExpense.Please();
            var groupExpenseInput = Create.GroupExpenseInput.HasPayment(0).Please();

            Assert.Throws<ArgumentException>(() => groupExpense.Change(groupExpenseInput));
        }

        [Test]
        public void When_PaymentPersonIsDuplicated_Then_ThrowArgumentExeption()
        {
            var groupExpense = Create.GroupExpense.Please();

            var duplicatedPersonId = Guid.NewGuid();
            var groupExpenseInput = Create.GroupExpenseInput
                .WithPayment(Dollars.Amount(100).Of(duplicatedPersonId))
                .WithPayment(Dollars.Amount(100).Of(duplicatedPersonId))
                .Please();

            Assert.Throws<ArgumentException>(() => groupExpense.Change(groupExpenseInput));
        }

        [Test]
        public void ChangeGroupExpense_PaymentsHaveNullPayment_ThrowArgumentException()
        {
            var groupExpense = Create.GroupExpense.Please();
            var groupExpenseInput = Create.GroupExpenseInput
                .HasNullPayment()
                .HasPayment(100)
                .Please();

            Assert.Throws<ArgumentException>(() => groupExpense.Change(groupExpenseInput));
        }

        [Test]
        public void Then_NullExpenses_ThrowArgumentNullExeption()
        {
            var groupExpense = Create.GroupExpense.Please();
            var groupExpenseInput = Create.GroupExpenseInput
                .WithAnyPayments()
                .WithNullExpenses()
                .Please();

            Assert.Throws<ArgumentNullException>(() => groupExpense.Change(groupExpenseInput));
        }

        [Test]
        public void Then_InputHasEmptyExpenses_Then_ThrowArgumentException(
            [Values(null)] IEnumerable<MoneyOperation> expenses)
        {
            var groupExpense = Create.GroupExpense.Please();
            var groupExpenseInput = Create.GroupExpenseInput
                .WithAnyPayments()
                .WithEmptyExpenses()
                .Please();

            Assert.Throws<ArgumentException>(() => groupExpense.Change(groupExpenseInput));
        }

        [Test]
        public void When_InputHasZeroAmountExpense_ThrowArgumentException()
        {
            var groupExpense = Create.GroupExpense.Please();
            var groupExpenseInput = Create.GroupExpenseInput
                .WithPayment(100.Dollars().OfAnyone())
                .WithExpense(100.Dollars().OfAnyone())
                .WithExpense(0.Dollars().OfAnyone())
                .Please();

            Assert.Throws<ArgumentException>(() => groupExpense.Change(groupExpenseInput));
        }

        [Test]
        public void When_ExpensePersonIsDuplicated_Then_ThrowArgumentException()
        {
            var groupExpense = Create.GroupExpense.Please();

            var duplicatedPersonId = Guid.NewGuid();
            var groupExpenseInput = Create.GroupExpenseInput
                .WithPayment(200.Dollars().OfAnyone())
                .WithExpense(100.Dollars().Of(duplicatedPersonId))
                .WithExpense(100.Dollars().Of(duplicatedPersonId))
                .Please();

            Assert.Throws<ArgumentException>(() => groupExpense.Change(groupExpenseInput));
        }

        [Test]
        public void When_InputHasNullExpense_Then_ThrowArgumentException()
        {
            var groupExpense = Create.GroupExpense.Please();
            var groupExpenseInput = Create.GroupExpenseInput
                .WithPayment(100.Dollars().OfAnyone())
                .WithExpense(null)
                .Please();

            Assert.Throws<ArgumentException>(() => groupExpense.Change(groupExpenseInput));
        }

        [Test]
        public void When_PaymentsTotalAmountIsNotEqualExpensesTotalAmount_Then_ThrowArgumentExeption()
        {
            var groupExpense = Create.GroupExpense.Please();

            var groupExpenseInput = Create.GroupExpenseInput
                .WithPayment(200.Dollars().OfAnyone())
                .WithExpense(100.Dollars().OfAnyone())
                .Please();

            Assert.Throws<ArgumentException>(() => groupExpense.Change(groupExpenseInput));
        }
    }
}