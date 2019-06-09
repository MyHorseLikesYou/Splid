using System;
using Splid.Domain.Main.Values;

namespace Splid.Domain.Main.Tests.Builders.Groups.Inputs
{
    public class PaymentInputBuilder : IBuilder<PaymentInput>
    {
        private PaymentInput _paymentInput;

        public PaymentInputBuilder()
        {
            _paymentInput = new PaymentInput()
            {
                SenderId = Guid.NewGuid(),
                RecipientId = Guid.NewGuid(),
                Amount = new Money(100),
                Date = DateTimeOffset.Now,
            };
        }

        public PaymentInputBuilder With(Guid senderPersonId, Guid recipientPersonId, decimal amount)
        {
            _paymentInput.SenderId = senderPersonId;
            _paymentInput.RecipientId = recipientPersonId;

            return this;
        }

        public PaymentInputBuilder With(Guid senderPersonId, Guid recipientPersonId) =>
            With(senderPersonId, recipientPersonId, 100);

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

        public PaymentInput Please()
        {
            return _paymentInput;
        }
    }
}
