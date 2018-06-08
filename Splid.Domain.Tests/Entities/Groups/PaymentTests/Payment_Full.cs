using NUnit.Framework;
using Splid.Domain.Main.Entities.Groups;
using Splid.Domain.Main.Values;
using Splid.Domain.Models.Groups;
using System;

namespace Splid.Domain.Tests.Entities.Groups.PaymentTests
{
    [TestFixture]
    public class Payment_Full
    {
        private static DateTimeOffset PastDate = DateTimeOffset.Now.Date.AddDays(-1);
        private static DateTimeOffset FutureDate = DateTimeOffset.Now.Date.AddDays(1);

        [Test]
        public void Construct_PersonFromEqualsPersonTo_ThrowArgumentException()
        {
            var personId = Guid.NewGuid();

            Assert.Throws<ArgumentException>(() => new Payment(Guid.NewGuid(), personId, personId, new Money(100), PastDate, PastDate));
        }

        [Test]
        public void Construct_NullAmount_ThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new Payment(Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), null, PastDate, PastDate));
        }

        [Test]
        public void Construct_DateInFuture_ThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new Payment(Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), new Money(100), FutureDate, PastDate));
        }

        [Test]
        public void Construct_CreatedAtDateTimeInFuture_ThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new Payment(Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), new Money(100), PastDate, FutureDate));
        }

        [Test]
        public void Construct_NullInput_ThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => Payment.Create(Guid.NewGuid(), null));
        }

        [Test]
        public void Construct_ValidArguments_NotNull()
        {
            var payment = new Payment(Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), new Money(100), PastDate, PastDate);

            Assert.NotNull(payment);
        }

        [Test]
        public void Create_NullInput_ThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => Payment.Create(Guid.NewGuid(), null));
        }

        [Test]
        public void Create_ValidArguments_NotNull()
        {
            var paymentInput = new PaymentInput()
            {
                PersonById = Guid.NewGuid(),
                PersonForId = Guid.NewGuid(),
                Date = PastDate,
                Amount = new Money(100),                
            };

            var payment = Payment.Create(Guid.NewGuid(), paymentInput);

            Assert.NotNull(payment);
        }

        [Test]
        public void SetDate_DateInFuture_ThrowArgumentException()
        {
            var payment = new Payment(Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), new Money(100), PastDate, PastDate);

            Assert.Throws<ArgumentException>(() => payment.Date = FutureDate);
        }

        [Test]
        public void SetDate_DateValid_AreEqual()
        {
            var payment = new Payment(Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), new Money(100), PastDate, PastDate);

            payment.Date = PastDate;

            Assert.AreEqual(payment.Date, PastDate);
        }

        [Test]
        public void SetAmount_NullAmount_ThrowArgumentNullException()
        {
            var payment = new Payment(Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), new Money(100), PastDate, PastDate);

            Assert.Throws<ArgumentNullException>(() => payment.Amount = null);
        }

        [Test]
        public void SetAmount_ValidAmount_AreEqual()
        {
            var payment = new Payment(Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), new Money(100), PastDate, PastDate);
            var newAmount = new Money(300);

            payment.Amount = newAmount;

            Assert.AreEqual(payment.Amount, newAmount);
        }

        [Test]
        public void SetPersonFrom_EqualsPersonTo_ThrowArgumentException()
        {
            var personTo = Guid.NewGuid();
            var payment = new Payment(Guid.NewGuid(), Guid.NewGuid(), personTo, new Money(100), PastDate, PastDate);

            Assert.Throws<ArgumentException>(() => payment.PersonFromId = personTo);
        }

        [Test]
        public void SetPersonFrom_NotEqualsPersonTo_AreEqual()
        {
            var payment = new Payment(Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), new Money(100), PastDate, PastDate);
            var newPersonFrom = Guid.NewGuid();

            payment.PersonFromId = newPersonFrom;

            Assert.AreEqual(payment.PersonFromId, newPersonFrom);
        }

        [Test]
        public void SetPersonTo_EqualsPersonFrom_ThrowArgumentException()
        {
            var personFrom = Guid.NewGuid();
            var payment = new Payment(Guid.NewGuid(), personFrom, Guid.NewGuid(), new Money(100), PastDate, PastDate);

            Assert.Throws<ArgumentException>(() => payment.PersonToId = personFrom);
        }

        [Test]
        public void SetPersonTo_NotEqualsPersonFrom_AreEqual()
        {
            var payment = new Payment(Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), new Money(100), PastDate, PastDate);
            var newPersonTo = Guid.NewGuid();

            payment.PersonToId = newPersonTo;

            Assert.AreEqual(payment.PersonToId, newPersonTo);
        }
    }
}
