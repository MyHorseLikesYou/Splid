using MyApp.Core.Domain;
using System;

namespace Splid.Domain.Main.Values
{
    public class PersonMoneyOperation : Value
    {
        public Guid PersonId { get; }
        public Money Amount { get; }

        public PersonMoneyOperation(Guid personId, Money amount)
        {
            this.PersonId = personId;
            this.Amount = amount ?? throw new ArgumentNullException(nameof(amount));
        }
    }
}
