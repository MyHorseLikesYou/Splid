using NUnit.Framework;
using Splid.Domain.Tests.Builders.Groups.Entities;
using Splid.Domain.Tests.Builders.Groups.Inputs;
using System;
using System.Linq;

namespace Splid.Domain.Tests.Entities.Groups.GroupTests
{
    [TestFixture]
    public class Group_AddPayment
    {
        [Test]
        public void AddPayment_NullPaymentInput_ArgumentNullException()
        {
            var group = GroupBuilder.New().Build();

            Assert.Throws<ArgumentNullException>(() => group.AddPayment(Guid.NewGuid(), null));
        }

        [Test]
        public void AddPayment_UnknownPaymentPersonBy_ThrowArgumentException()
        {
            var paymentForPersonId = Guid.NewGuid();
            var group = GroupBuilder.New()
                .HavePersonsWithIds(paymentForPersonId)
                .Build();

            var unknownPaymentByPersonId = Guid.NewGuid();
            var paymentInput = PaymentInputBuilder.New()
                .Set(unknownPaymentByPersonId, paymentForPersonId, 100)
                .Build();

            Assert.Throws<ArgumentException>(() => group.AddPayment(Guid.NewGuid(), paymentInput));
        }

        [Test]
        public void AddPayment_UnknownPaymentPersonFor_ThrowArgumentException()
        {
            var paymentByPersonId = Guid.NewGuid();
            var group = GroupBuilder.New()
                .HavePersonsWithIds(paymentByPersonId)
                .Build();

            var unknownPaymentForPersonId = Guid.NewGuid();
            var paymentInput = PaymentInputBuilder.New()
                .Set(paymentByPersonId, unknownPaymentForPersonId, 100)
                .Build();

            Assert.Throws<ArgumentException>(() => group.AddPayment(Guid.NewGuid(), paymentInput));
        }

        [Test]
        public void AddPayment_ValidArguments_GroupHasPayment()
        {
            var paymentByPersonId = Guid.NewGuid();
            var paymentForPersonId = Guid.NewGuid();

            var group = GroupBuilder.New()
                .HavePersonsWithIds(paymentByPersonId, paymentForPersonId)
                .Build();

            var paymentId = Guid.NewGuid();
            var paymentInput = PaymentInputBuilder.New()
                .Set(paymentByPersonId, paymentForPersonId, 1000)
                .Build();

            group.AddPayment(paymentId, paymentInput);

            Assert.That(group.Payments.Any(e => e.Id == paymentId));
        }
    }
}
