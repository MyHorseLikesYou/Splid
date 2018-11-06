using System;
using System.Collections.Generic;
using MyApp.Core.Exceptions;
using NUnit.Framework;
using Splid.Domain.Main.Entities.Groups;
using Splid.Domain.Main.Services;

namespace Splid.Domain.Main.Tests.Services.PaymentServiceTests
{
    [TestFixture]
    public class CreatePayment : BaseTest
    {
        [Test]
        public void CreatePayment_NullInput_ThrowArgumentNullException()
        {
            var paymentService = New().PaymentService().Build();

            Assert.Throws<ArgumentNullException>(() => paymentService.AddPayment(Guid.NewGuid(), Guid.NewGuid(), null));
        }

        [Test]
        public void CreatePayment_GroupNotExists_ThrowEntityNotFoundException()
        {
            var paymentInput = New().PaymentInput().Build();
            var paymentService = New().PaymentService().Build();            

            Assert.Throws<EntityNotFoundException<Group>>(() =>
                paymentService.AddPayment(Guid.NewGuid(), Guid.NewGuid(), paymentInput));
        }

        private static IEnumerable<TestCaseData> CreatePayment_UnknownPersonId_TestCaseData
        {
            get
            {
                var existingPersonId = Guid.NewGuid();
                var unknownPersonId = Guid.NewGuid();

                yield return new TestCaseData(new[] {existingPersonId}, existingPersonId, unknownPersonId);
                yield return new TestCaseData(new[] {existingPersonId}, unknownPersonId, existingPersonId);
            }
        }

        [TestCaseSource(nameof(CreatePayment_UnknownPersonId_TestCaseData))]
        public void CreatePayment_UnknownPersonId_ThrowInvalidDomainOperationException(Guid[] groupPersonsIds,
            Guid senderId,
            Guid recipientId)
        {
            var groupId = Guid.NewGuid();
            var group = New().Group()
                .WithId(groupId)
                .HavePersonsWithIds(groupPersonsIds)
                .Build();
            var groupRepository = New().GroupRepository()
                .WithGroups(group)
                .Build();

            var paymentRepository = New().PaymentRepository().Build();
            
            var paymentService = New().PaymentService()
                .With(paymentRepository, groupRepository)
                .Build();
            
            var paymentInput = New().PaymentInput()
                .With(senderId, recipientId)
                .Build();

            Assert.Throws<InvalidDomainOperationException>(() =>
                paymentService.AddPayment(groupId, Guid.NewGuid(), paymentInput));
        }
    }
}