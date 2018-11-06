using System;
using NUnit.Framework;

namespace Splid.Domain.Main.Tests.Entities.Groups.PaymentTests
{
    [TestFixture]
    public class Payment_Change : BaseTest
    {
        [Test]
        public void ChangePayment_NullInput_ThrowArgumentNullException()
        {
            var payment = New().Payment().Build();

            Assert.Throws<ArgumentNullException>(() => payment.Change(null));
        }

        [Test]
        public void ChangePayment_DateInFuture_ThrowArgumentException()
        {
            var payment = New().Payment().Build();
            var paymentInput = New().PaymentInput().WithDateInFuture().Build();

            Assert.Throws<ArgumentException>(() => payment.Change(paymentInput));
        }

        [Test]
        public void ChangePayment_NullAmount_ThrowArgumentException()
        {
            var payment = New().Payment().Build();
            var paymentInput = New().PaymentInput().WithAmount(0).Build();

            Assert.Throws<ArgumentException>(() => payment.Change(paymentInput));
        }

        [Test]
        public void ChangePayment_SenderEqualsToRecipient_ThrowArgumentException()
        {            
            var payment = New().Payment().Build();

            var personId = Guid.NewGuid();
            var paymentInput = New().PaymentInput().With(personId, personId, 100).Build();

            Assert.Throws<ArgumentException>(() => payment.Change(paymentInput));
        }

        [Test]
        public void ChangePayment_ValidArguments_DoesNotThrow()
        {
            var payment = New().Payment().Build();
            var paymentInput = New().PaymentInput().Build();

            Assert.DoesNotThrow(() => payment.Change(paymentInput));
        }
    }
}
