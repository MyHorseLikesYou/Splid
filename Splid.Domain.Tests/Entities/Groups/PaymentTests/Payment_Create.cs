using NUnit.Framework;
using Splid.Domain.Main.Entities.Groups;
using Splid.Domain.Main.Values;
using Splid.Domain.Models.Groups;
using System;

namespace Splid.Domain.Tests.Entities.Groups.PaymentTests
{
    [TestFixture]
    public class Payment_Create
    {
        private static DateTimeOffset PastDate = DateTimeOffset.Now.Date.AddDays(-1);
        private static DateTimeOffset FutureDate = DateTimeOffset.Now.Date.AddDays(1);

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
    }
}
