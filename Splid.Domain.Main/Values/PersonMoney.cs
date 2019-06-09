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
            PersonId = personId;
            Amount = amount ?? throw new ArgumentNullException(nameof(amount));
        }
    }
}
