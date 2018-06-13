using Splid.Domain.Main.Entities.Groups;
using System;

namespace Splid.Domain.Tests.Builders.Groups.Entities
{
    public class PaymentBuilder : IBuilder<Payment>
    {
        private Guid _id;
        private Guid _senderId;
        private Guid _recipientId;
        private decimal _amount;

        public PaymentBuilder()
        {
            _id = Guid.NewGuid();
            _senderId = Guid.NewGuid();
            _recipientId = Guid.NewGuid();
            _amount = 110;
        }

        public Payment Build()
        {
            return new Payment(_id, _senderId, _recipientId, new Main.Values.Money(_amount), DateTimeOffset.Now.Date, DateTimeOffset.Now);
        }

        public PaymentBuilder WithId(Guid id)
        {
            _id = id;

            return this;
        }

        public PaymentBuilder With(Guid paymentByPersonId, Guid paymentForPersonId, decimal amount)
        {
            _senderId = paymentByPersonId;
            _recipientId = paymentForPersonId;
            _amount = amount;

            return this;
        }
    }
}
