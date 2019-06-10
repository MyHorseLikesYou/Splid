using System;
using NUnit.Framework;
using Splid.Domain.Main.Tests.Builders;
using Splid.Domain.Main.Tests.Builders.Constants.Values;
using Splid.Domain.Main.Tests.Builders.Groups.Values;

namespace Splid.Domain.Main.Tests.Entities.Groups.ExpenseTests
{
    [TestFixture]
    public class GroupExpense_Change : BaseTest
    {
        [Test]
        public void ChangeGroupExpense_NullInput_ThrowArgumentNullExeption()
        {
            var groupExpense = New().GroupExpense().Build();

            Assert.Throws<ArgumentNullException>(() => groupExpense.Change(null));
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void ChangeGroupExpense_InvalidTitle_ThrowArgumentExeption(string title)
        {
            var groupExpense = New().GroupExpense().Build();
            var groupExpenseInput = New().GroupExpenseInput().WithTitle(title).Build();

            Assert.Throws<ArgumentException>(() => groupExpense.Change(groupExpenseInput));
        }

        [Test]
        public void ChangeGroupExpense_DateInFuture_ThrowArgumentExeption()
        {
            var groupExpense = New().GroupExpense().Build();
            var groupExpenseInput = New().GroupExpenseInput().WithFutureDate().Build();

            Assert.Throws<ArgumentException>(() => groupExpense.Change(groupExpenseInput));
        }

        [Test]
        public void ChangeGroupExpense_NullPayments_ThrowArgumentNullExeption()
        {
            var groupExpense = New().GroupExpense().Build();
            var groupExpenseInput = New().GroupExpenseInput().WithNullPayments().Build();

            Assert.Throws<ArgumentNullException>(() => groupExpense.Change(groupExpenseInput));
        }

        [Test]
        public void ChangeGroupExpense_EmptyPayments_ThrowArgumentExeption()
        {
            var groupExpense = New().GroupExpense().Build();
            var groupExpenseInput = New().GroupExpenseInput().WithEmptyPayments().Build();

            Assert.Throws<ArgumentException>(() => groupExpense.Change(groupExpenseInput));
        }

        [Test]
        public void ChangeGroupExpense_PaymentsHaveZeroAmountPayment_ThrowArgumentExeption()
        {
            var groupExpense = New().GroupExpense().Build();
            var groupExpenseInput = New().GroupExpenseInput().HasPayment(0).Build();

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
            var groupExpense = New().GroupExpense().Build();
            var groupExpenseInput = New().GroupExpenseInput()
                .HasNullPayment()
                .HasPayment(100)
                .Build();

            Assert.Throws<ArgumentException>(() => groupExpense.Change(groupExpenseInput));
        }

        [Test]
        public void ChangeGroupExpense_NullExpenses_ThrowArgumentNullExeption()
        {
            var groupExpense = New().GroupExpense().Build();
            var groupExpenseInput = New().GroupExpenseInput().WithNullExpenses().Build();

            Assert.Throws<ArgumentNullException>(() => groupExpense.Change(groupExpenseInput));
        }

        [Test]
        public void ChangeGroupExpense_EmptyExpenses_ThrowArgumentExeption()
        {
            var groupExpense = New().GroupExpense().Build();
            var groupExpenseInput = New().GroupExpenseInput().WithEmptyExpenses().Build();

            Assert.Throws<ArgumentException>(() => groupExpense.Change(groupExpenseInput));
        }

        [Test]
        public void ChangeGroupExpense_ExpensesHaveZeroAmountExpense_ThrowArgumentExeption()
        {
            var groupExpense = New().GroupExpense().Build();
            var groupExpenseInput = New().GroupExpenseInput().HasExpense(0).Build();

            Assert.Throws<ArgumentException>(() => groupExpense.Change(groupExpenseInput));
        }

        [Test]
        public void ChangeGroupExpense_DuplicateExpensePerson_ThrowArgumentExeption()
        {
            var groupExpense = New().GroupExpense().Build();

            var personIdThatWillDuplicate = Guid.NewGuid();
            var groupExpenseInput = New().GroupExpenseInput()
                .HasPayment(200)
                .HasExpense(personIdThatWillDuplicate, 100)
                .HasExpense(personIdThatWillDuplicate, 100)
                .Build();

            Assert.Throws<ArgumentException>(() => groupExpense.Change(groupExpenseInput));
        }

        [Test]
        public void ChangeGroupExpense_ExpensesHaveNullExpense_ThrowArgumentException()
        {
            var groupExpense = New().GroupExpense().Build();
            var groupExpenseInput = New().GroupExpenseInput()
                .HasNullExpense()                
                .HasPayment(100)
                .Build();

            Assert.Throws<ArgumentException>(() => groupExpense.Change(groupExpenseInput));
        }

        [Test]
        public void ChangeGroupExpense_PaymentsTotalAmountIsNotEqualExpensesTotalAmount_ThrowArgumentExeption()
        {
            var groupExpense = New().GroupExpense().Build();

            var personIdThatWillDuplicate = Guid.NewGuid();
            var groupExpenseInput = New().GroupExpenseInput()
                .HasPayment(200)
                .HasExpense(100)
                .Build();

            Assert.Throws<ArgumentException>(() => groupExpense.Change(groupExpenseInput));
        }
    }
}
