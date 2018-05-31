using MyApp.Core.Domain;
using Splid.Domain.Main.Values;
using Splid.Domain.Models.Groups;
using System;

namespace Splid.Domain.Main.Entities.Groups
{
    public class Payment : Entity
    {
        private DateTimeOffset _createdAt;

        private Guid _personFromId { get; set; }
        public Guid PersonFromId
        {
            get => _personFromId;
            set
            {
                ValidateAreNotEqual(value, _personToId);
                _personFromId = value;
            }
        }

        public Guid _personToId { get; set; }
        public Guid PersonToId
        {
            get => _personToId;
            set
            {
                ValidateAreNotEqual(_personFromId, value);
                _personToId = value;
            }
        }

        private Money _amount;
        public Money Amount
        {
            get => _amount;
            set
            {
                ValidateNotNull(value);
                _amount = value;
            }
        }

        private DateTimeOffset _date;
        public DateTimeOffset Date
        {
            get => _date;
            set
            {
                ValidateNotInFuture(value.Date);
                _date = value.Date;
            }
        }

        public Payment(PaymentInput paymentInput)
            : this(paymentInput.Id, paymentInput.PersonFromId, paymentInput.PersonToId, paymentInput.Amount, paymentInput.Date)
        { }

        public Payment(Guid id, Guid personFromId, Guid personToId, Money amount, DateTimeOffset date)
            : this(id, personFromId, personToId, amount, date, DateTime.Now)
        { }

        public Payment(Guid id, Guid personFromId, Guid personToId, Money amount, DateTimeOffset date, DateTimeOffset createdAt)
            : base(id)
        {
            ValidateAreNotEqual(personFromId, personToId);
            ValidateNotInFuture(createdAt);
            ValidateNotInFuture(date);
            ValidateNotNull(amount);

            _personFromId = personFromId;
            _personToId = personToId;
            _amount = amount;
            _date = date;
            _createdAt = createdAt;
        }

        private static void ValidateAreNotEqual(Guid personFromId, Guid personToId)
        {
            if (personFromId == personToId)
                throw new ArgumentException($"{nameof(personFromId)} не может быть равно {nameof(personToId)}.");
        }

        private static void ValidateNotInFuture(DateTimeOffset dateTime)
        {
            if (dateTime > DateTimeOffset.Now)
                throw new ArgumentException();
        }

        private static void ValidateNotNull(object obj)
        {
            if (obj == null)
                throw new ArgumentNullException();
        }
    }
}
