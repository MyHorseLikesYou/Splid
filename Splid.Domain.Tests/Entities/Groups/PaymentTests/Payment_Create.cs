using NUnit.Framework;
using Splid.Domain.Main.Entities.Groups;
using System;

namespace Splid.Domain.Tests.Entities.Groups.PaymentTests
{
    [TestFixture]
    public class Payment_Create : BaseTest
    {
        [Test]
        public void CreatePerson_NullInput_ThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => Payment.Create(Guid.NewGuid(), null));
        }

        [Test]
        public void CreatePerson_ValidArguments_NotNull()
        {
            var paymentInput = New().PaymentInput().Build();

            Assert.DoesNotThrow(() => Payment.Create(Guid.NewGuid(), paymentInput));
        }
    }
}
