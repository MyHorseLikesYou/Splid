using NUnit.Framework;
using Splid.Domain.Tests.Builders;
using Splid.Domain.Tests.Builders.Groups.Entities;
using Splid.Domain.Tests.Builders.Groups.Inputs;
using System;

namespace Splid.Domain.Tests.Entities.Groups.GroupTests
{
    [TestFixture]
    public class Group_ChangePayment
    {
        [Test]
        public void ChangePayment_NullPaymentInput_ThrowArgumentNullException()
        {
            var paymentId = Guid.NewGuid();
            var group = GroupBuilder.New()                
                .AddPayment(paymentId)
                .Build();

            Assert.Throws<ArgumentNullException>(() => group.ChangePayment(paymentId, null));
        }

        [Test]
        public void ChangePayment_UnknownPayment_ThrowArgumentException()
        {
            var group = GroupBuilder.New().Build();
            var paymentInput = New().PaymentInput().Build();
            var unknownPaymentId = Guid.NewGuid();

            Assert.Throws<ArgumentException>(() => group.ChangePayment(unknownPaymentId, paymentInput));
        }

        [Test]
        public void ChangePayment_UnknownPaymentByPerson_ThrowArgumentException()
        {
            var paymentId = Guid.NewGuid();
            var paymentByPersonId = Guid.NewGuid();
            var paymentForPersonId = Guid.NewGuid();
            var group = GroupBuilder.New()
                .AddPayment(paymentId, paymentByPersonId, paymentForPersonId, 100)
                .Build();

            var unknowPaymentByPersonId = Guid.NewGuid();
            var paymentInput = New().PaymentInput()
                .With(unknowPaymentByPersonId, paymentForPersonId, 100)
                .Build();

            Assert.Throws<ArgumentException>(() => group.ChangePayment(paymentId, paymentInput));
        }

        [Test]
        public void ChangePayment_UnknowPaymentForPerson_ThrowArgumentException()
        {
            var paymentId = Guid.NewGuid();
            var paymentByPersonId = Guid.NewGuid();
            var paymentForPersonId = Guid.NewGuid();
            var group = GroupBuilder.New()
                .AddPayment(paymentId, paymentByPersonId, paymentForPersonId, 100)
                .Build();

            var unknowPaymentForPersonId = Guid.NewGuid();
            var paymentInput = New().PaymentInput()
                .With(paymentByPersonId, unknowPaymentForPersonId, 100)
                .Build();

            Assert.Throws<ArgumentException>(() => group.ChangePayment(paymentId, paymentInput));
        }

        [Test]
        public void ChangePayment_ValidArguments_DoesNotThrow()
        {
            var paymentId = Guid.NewGuid();
            var paymentByPersonId = Guid.NewGuid();
            var paymentForPersonId = Guid.NewGuid();
            var group = GroupBuilder.New()
                .AddPayment(paymentId, paymentByPersonId, paymentForPersonId, 100)
                .Build();

            var PaymentInput = New().PaymentInput()
                .With(paymentByPersonId, paymentForPersonId, 1000)
                .Build();

            Assert.DoesNotThrow(() => group.ChangePayment(paymentId, PaymentInput));
        }

        private BuilderFactory New()
        {
            return new BuilderFactory();
        }
    }
}
