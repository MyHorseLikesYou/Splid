using System;
using System.Collections.Generic;
using MyApp.Core.Exceptions;
using NUnit.Framework;
using Splid.Domain.Main.Entities.Groups;
using Splid.Domain.Main.Tests.Builders.Groups.Entities;

namespace Splid.Domain.Main.Tests.Services.PaymentServiceTests
{
    [TestFixture]
    public class ChangePayment : BaseTest
    {
        [Test]
        public void ChangePayment_NullInput_ThrowArgumentNullException()
        {
            var paymentService = New().PaymentService().Build();

            Assert.Throws<ArgumentNullException>(() => paymentService.ChangePayment(Guid.NewGuid(), null));
        }

        [Test]
        public void ChangePayment_PaymentNotExists_ThrowEntityNotFoundException()
        {
            var paymentInput = New().PaymentInput().Build();
            var paymentService = New().PaymentService().Build();

            Assert.Throws<EntityNotFoundException<Payment>>(() =>
                paymentService.ChangePayment(Guid.NewGuid(), paymentInput));
        }

        private static IEnumerable<TestCaseData> ChangePayment_UnknownPersonId_TestCaseData
        {
            get
            {
                var senderId = Guid.NewGuid();
                var recipientId = Guid.NewGuid();
                var unknownPersonId = Guid.NewGuid();

                yield return new TestCaseData(senderId, recipientId, unknownPersonId, recipientId);
                yield return new TestCaseData(senderId, recipientId, senderId, recipientId);
            }
        }

        [TestCaseSource(nameof(ChangePayment_UnknownPersonId_TestCaseData))]
        public void ChangePayment_UnknownPersonId_ThrowInvalidDomainOperationException(Guid senderId, Guid newSenderId,
            Guid recipientId, Guid newRecipientId)
        {
            var groupId = Guid.NewGuid();
            var group = New().Group()
                .WithId(groupId)
                .HavePersonsWithIds(senderId, recipientId)
                .Build();
            var groupRepository = New().GroupRepository()
                .WithGroups(group)
                .Build();

            var paymentId = Guid.NewGuid();
            var payment = New().Payment()
                .WithId(paymentId)
                .WithGroupId(groupId)
                .With(senderId, recipientId)
                .Build();
            var paymentRepository = New().PaymentRepository()
                .WithPayments(payment)
                .Build();
            
            var paymentService = New().PaymentService()
                .With(paymentRepository, groupRepository)
                .Build();

            var paymentInput = New().PaymentInput()
                .With(newSenderId, newRecipientId)
                .Build();

            Assert.Throws<InvalidDomainOperationException>(() =>
                paymentService.ChangePayment(paymentId, paymentInput));
        }
    }
}