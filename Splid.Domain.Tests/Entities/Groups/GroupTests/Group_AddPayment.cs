using NUnit.Framework;
using System;
using System.Linq;

namespace Splid.Domain.Tests.Entities.Groups.GroupTests
{
    [TestFixture]
    public class Group_AddPayment : BaseTest
    {
        [Test]
        public void AddPayment_NullInput_ArgumentNullException()
        {
            var group = New().Group().Build();

            Assert.Throws<ArgumentNullException>(() => group.AddPayment(Guid.NewGuid(), null));
        }

        [Test]
        public void AddPayment_UnknownPaymentPersonBy_ThrowArgumentException()
        {
            var paymentForPersonId = Guid.NewGuid();
            var group = New().Group()
                .HavePersonsWithIds(paymentForPersonId)
                .Build();

            var unknownPaymentByPersonId = Guid.NewGuid();
            var paymentInput = New().PaymentInput()
                .With(unknownPaymentByPersonId, paymentForPersonId, 100)
                .Build();

            Assert.Throws<ArgumentException>(() => group.AddPayment(Guid.NewGuid(), paymentInput));
        }

        [Test]
        public void AddPayment_UnknownPaymentPersonFor_ThrowArgumentException()
        {
            var paymentByPersonId = Guid.NewGuid();
            var group = New().Group()
                .HavePersonsWithIds(paymentByPersonId)
                .Build();

            var unknownPaymentForPersonId = Guid.NewGuid();
            var paymentInput = New().PaymentInput()
                .With(paymentByPersonId, unknownPaymentForPersonId, 100)
                .Build();

            Assert.Throws<ArgumentException>(() => group.AddPayment(Guid.NewGuid(), paymentInput));
        }

        [Test]
        public void AddPayment_ValidArguments_GroupHasPayment()
        {
            var paymentByPersonId = Guid.NewGuid();
            var paymentForPersonId = Guid.NewGuid();

            var group = New().Group()
                .HavePersonsWithIds(paymentByPersonId, paymentForPersonId)
                .Build();

            var paymentId = Guid.NewGuid();
            var paymentInput = New().PaymentInput()
                .With(paymentByPersonId, paymentForPersonId, 1000)
                .Build();

            group.AddPayment(paymentId, paymentInput);

            Assert.That(group.Payments.Any(e => e.Id == paymentId));
        }
    }
}
