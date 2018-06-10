using NUnit.Framework;
using Splid.Domain.Main.Entities.Groups;
using Splid.Domain.Main.Values;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Splid.Domain.Tests.Entities.Groups.ExpenseTests
{
    [TestFixture]
    public class GroupExpense_Construct
    {
        [Test]
        public void Construct_InvalidId_ThrowArgumentException()
        {
            //Assert.Throws<ArgumentNullException>(() => new GroupExpense(Guid.Empty, ));
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void Construct_InvalidTitle_ThrowArgumentException()
        {

        }

        [Test]
        public void Construct_DateInFuture_ThrowArgumentException()
        {

        }

        [Test]
        public void Construct_CreatedAtDateTimeInFuture_ThrowArgumentException()
        {
        }

        [Test, TestCaseSource(nameof(Construct_InvalidPayments_Set))]
        public void Construct_InvalidPayments_ThrowArgumentException()
        {

        }


        private class Construct_InvalidPayments_Set : IEnumerable
        {
            public Construct_InvalidPayments_Set()
            {

            }

            public IEnumerator GetEnumerator()
            {
                yield return null;
                yield return new List<PersonMoneyOperation>();
                yield return new List<PersonMoneyOperation>();
            }
        }
    }
}
