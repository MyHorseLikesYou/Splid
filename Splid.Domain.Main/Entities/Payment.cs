using System;
using MyApp.Core.Domain;
using Splid.Domain.Main.Models;
using Splid.Domain.Main.Values;

namespace Splid.Domain.Main.Entities
{
    public class Payment : Entity
    {
        private DateTimeOffset _createdAt;
        private Guid _sender;
        private Guid _recipient;
        private Money _amount;
        private DateTimeOffset _date;

        public Payment(Guid id, Guid senderId, Guid recipientId, Money amount, DateTimeOffset date, DateTimeOffset createdAt)
            : base(id)
        {
            ValidatePersonsAreNotEqual(senderId, recipientId);
            ValidateDateNotInFuture(createdAt);
            ValidateDateNotInFuture(date);
            ValidateArgumentForAmount(amount);

            _sender = senderId;
            _recipient = recipientId;
            _amount = amount;
            _date = date;
            _createdAt = createdAt;
        }

        public Guid PersonFromId
        {
            get => _sender;
            set
            {
                
                _sender = value;
            }
        }

        public Guid PersonToId
        {
            get => _recipient;
            set
            {
                ValidatePersonsAreNotEqual(_sender, value);
                _recipient = value;
            }
        }

        public Money Amount
        {
            get => _amount;
            set
            {

            }
        }

        public DateTimeOffset Date
        {
            get => _date;
            set
            {

            }
        }

        public Guid GroupId { get; set; }

        private static void ValidatePersonsAreNotEqual(Guid personFromId, Guid personToId)
        {
            if (personFromId == personToId)
                throw new ArgumentException($"{nameof(personFromId)} не может быть равно {nameof(personToId)}.");
        }

        private static void ValidateArgumentForAmount(Money amount)
        {
            if (amount == null)
                throw new ArgumentNullException();

            if(amount.Value == 0)
                throw new ArgumentException();
        }

        private static void ValidateDateNotInFuture(DateTimeOffset dateTime)
        {
            if (dateTime > DateTimeOffset.Now)
                throw new ArgumentException();
        }

        public void Change(PaymentInput paymentInput)
        {
            if (paymentInput == null)
                throw new ArgumentNullException();

            ValidatePersonsAreNotEqual(paymentInput.SenderId, paymentInput.RecipientId);
            ValidateDateNotInFuture(paymentInput.Date);
            ValidateArgumentForAmount(paymentInput.Amount);

            _sender = paymentInput.SenderId;
            _recipient = paymentInput.RecipientId;
            _date = paymentInput.Date;            
            _amount = paymentInput.Amount;
        }

        public static Payment Create(Guid id, PaymentInput paymentInput)
        {
            if (paymentInput == null)
                throw new ArgumentNullException();

            return new Payment(id, paymentInput.SenderId, paymentInput.RecipientId, paymentInput.Amount, paymentInput.Date, DateTimeOffset.Now);
        }
    }
}
