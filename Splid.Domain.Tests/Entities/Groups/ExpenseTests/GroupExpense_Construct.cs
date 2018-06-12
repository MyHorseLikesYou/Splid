using NUnit.Framework;
using Splid.Domain.Main.Entities.Groups;
using Splid.Domain.Main.Values;
using Splid.Domain.Tests.Entities.Groups.ExpenseTests.DataSets;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Splid.Domain.Tests.Entities.Groups.ExpenseTests
{
    [TestFixture]
    public class GroupExpense_Construct
    {
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void ConstructGroupExpense_InvalidTitle_ThrowArgumentException()
        {

        }

        [Test]
        public void ConstructGroupExpense_DateInFuture_ThrowArgumentException()
        {

        }

        [Test]
        public void ConstructGroupExpense_CreatedAtDateTimeInFuture_ThrowArgumentException()
        {
        }

        [Test, TestCaseSource(nameof(ConstructGroupExpense_InvalidPayments_DataSet))]
        public void ConstructGroupExpense_InvalidPayments_ThrowArgumentException()
        {

        }

        [Test, TestCaseSource(nameof(ConstructGroupExpense_InvalidExpenses_DataSet))]
        public void ConstructGroupExpense_InvalidExpenses_ThrowArgumentException()
        {

        }

        [Test]
        public void ConstructGroupExpense_PaymentsTotalAmountIsNotEqualExpensesTotalAmount_ThrowArgumentExeption()
        {

        }

        [Test]
        public void ConstructGroupExpense_ValidArguments_DoesNotThrow()
        {
            
        }
    }
}
