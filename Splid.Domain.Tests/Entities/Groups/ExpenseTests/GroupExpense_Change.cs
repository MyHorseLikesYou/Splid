using NUnit.Framework;
using Splid.Domain.Tests.Builders;
using System;

namespace Splid.Domain.Tests.Entities.Groups.ExpenseTests
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
        public void ChangeGroupExpense_NullPayments_ThrowArgumentExeption()
        {
            var groupExpense = New().GroupExpense().Build();
            var groupExpenseInput = New().GroupExpenseInput().WithNullPayments().Build();

            Assert.Throws<ArgumentException>(() => groupExpense.Change(groupExpenseInput));
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
        public void ChangeGroupExpense_DuplicatePaymentPerson_ThrowArgumentExeption()
        {            
            var groupExpense = New().GroupExpense().Build();

            var personIdThatWillDuplicate = Guid.NewGuid();
            var groupExpenseInput = New().GroupExpenseInput()
                .HasPayment(personIdThatWillDuplicate, 100)
                .HasPayment(personIdThatWillDuplicate, 100)
                .HasExpense(200)
                .Build();

            Assert.Throws<ArgumentException>(() => groupExpense.Change(groupExpenseInput));
        }

        [Test]
        public void ChangeGroupExpense_NullExpenses_ThrowArgumentExeption()
        {
            var groupExpense = New().GroupExpense().Build();
            var groupExpenseInput = New().GroupExpenseInput().WithNullExpenses().Build();

            Assert.Throws<ArgumentException>(() => groupExpense.Change(groupExpenseInput));
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
