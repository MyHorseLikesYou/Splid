using System;

namespace Splid.Domain.Main.Tests.Builders.Groups.Entities
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

        public Payment Please()
        {
            return new Payment(_id, _senderId, _recipientId, new Values.Money(_amount), DateTimeOffset.Now.Date, DateTimeOffset.Now);
        }

        public PaymentBuilder WithId(Guid id)
        {
            _id = id;

            return this;
        }

        public PaymentBuilder With(Guid paymentByPersonId, Guid paymentForPersonId, decimal amount = 100)
        {
            _senderId = paymentByPersonId;
            _recipientId = paymentForPersonId;
            _amount = amount;

            return this;
        }       

        public PaymentBuilder WithGroupId(Guid groupId)
        {
            throw new NotImplementedException();
        }
    }
}
