using MyApp.Core.Domain;
using Splid.Domain.Main.Values;
using Splid.Domain.Models.Groups;
using System;

namespace Splid.Domain.Main.Entities.Groups
{
    public class Payment : Entity
    {
        private DateTimeOffset _createdAt;
        private Guid _personFromId;
        private Guid _personToId;
        private Money _amount;
        private DateTimeOffset _date;
        private Guid paymentId;
        private PaymentInput paymentInput;

        public Payment(Guid id, Guid personFromId, Guid personToId, Money amount, DateTimeOffset date, DateTimeOffset createdAt)
            : base(id)
        {
            ValidatePersonsAreNotEqual(personFromId, personToId);
            ValidateDateNotInFuture(createdAt);
            ValidateDateNotInFuture(date);
            ValidateArgumentForAmount(amount);

            _personFromId = personFromId;
            _personToId = personToId;
            _amount = amount;
            _date = date;
            _createdAt = createdAt;
        }

        public Guid PersonFromId
        {
            get => _personFromId;
            set
            {
                ValidatePersonsAreNotEqual(value, _personToId);
                _personFromId = value;
            }
        }

        public Guid PersonToId
        {
            get => _personToId;
            set
            {
                ValidatePersonsAreNotEqual(_personFromId, value);
                _personToId = value;
            }
        }

        public Money Amount
        {
            get => _amount;
            set
            {
                ValidateArgumentForAmount(value);
                _amount = value;
            }
        }

        public DateTimeOffset Date
        {
            get => _date;
            set
            {
                ValidateDateNotInFuture(value.Date);
                _date = value.Date;
            }
        }

        private static void ValidatePersonsAreNotEqual(Guid personFromId, Guid personToId)
        {
            if (personFromId == personToId)
                throw new ArgumentException($"{nameof(personFromId)} не может быть равно {nameof(personToId)}.");
        }

        private static void ValidateArgumentForAmount(Money amount)
        {
            if (amount == null)
                throw new ArgumentNullException();
        }

        private static void ValidateDateNotInFuture(DateTimeOffset dateTime)
        {
            if (dateTime > DateTimeOffset.Now)
                throw new ArgumentException();
        }

        internal void Change(PaymentInput paymentInput)
        {
            throw new NotImplementedException();
        }

        public static Payment Create(Guid id, PaymentInput paymentInput)
        {
            if (paymentInput == null)
                throw new ArgumentNullException();

            return new Payment(id, paymentInput.PersonById, paymentInput.PersonForId, paymentInput.Amount, paymentInput.Date, DateTimeOffset.Now);
        }
    }
}
