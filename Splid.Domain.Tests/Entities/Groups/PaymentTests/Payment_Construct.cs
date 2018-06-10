using NUnit.Framework;
using Splid.Domain.Main.Entities.Groups;
using Splid.Domain.Main.Values;
using System;

namespace Splid.Domain.Tests.Entities.Groups.PaymentTests
{
    [TestFixture]
    public class Payment_Construct
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
    }
}
