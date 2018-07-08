using Splid.Domain.Main.Models.Groups;
using Splid.Domain.Main.Values;
using System;

namespace Splid.Domain.Tests.Builders.Groups.Inputs
{
    public class PaymentInputBuilder : IBuilder<PaymentInput>
    {
        private PaymentInput _paymentInput;

        public PaymentInputBuilder()
        {
            _paymentInput = new PaymentInput()
            {
                PersonById = Guid.NewGuid(),
                PersonForId = Guid.NewGuid(),
                Amount = new Money(100),
                Date = DateTimeOffset.Now,
            };
        }

        public PaymentInputBuilder With(Guid senderPersonId, Guid recipientPersonId, decimal amount)
        {
            _paymentInput.PersonById = senderPersonId;
            _paymentInput.PersonForId = recipientPersonId;

            return this;
        }

        public PaymentInputBuilder WithDateInFuture()
        {
            _paymentInput.Date = DateTimeOffset.Now.AddDays(1);
            return this;
        }

        public PaymentInputBuilder WithAmount(decimal amount)
        {
            _paymentInput.Amount = new Money(amount);
            return this;
        }

        public PaymentInput Build()
        {
            return _paymentInput;
        }
    }
}
