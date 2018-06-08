using MyApp.Core.Domain;
using System;

namespace Splid.Domain.Main.Values
{
    public class PersonMoney : Value
    {
        public Guid PersonId { get; }
        public Money Amount { get; }

        public PersonMoney(Guid personId, Money amount)
        {
            this.PersonId = personId;
            this.Amount = amount ?? throw new ArgumentNullException(nameof(amount));
        }
    }
}
