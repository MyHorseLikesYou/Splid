using MyApp.Core.Domain;
using System;

namespace Splid.Domain.Main.Values
{
    public class MoneyOperation : Value
    {
        public Guid PersonId { get; }
        public Money Amount { get; }

        public MoneyOperation(Guid personId, Money amount)
        {
            PersonId = personId;
            Amount = amount ?? throw new ArgumentNullException(nameof(amount));
        }
    }
}
