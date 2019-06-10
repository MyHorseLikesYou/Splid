using System;
using Splid.Domain.Main.Values;

namespace Splid.Domain.Main.Tests.Builders.Groups.Values
{
    public class MoneyOperationBuilder : IBuilder<MoneyOperation>
    {
        private Guid _personId;
        private Money _money;

        public MoneyOperationBuilder Of(Guid personId)
        {
            _personId = personId;
            return this;
        }

        public MoneyOperationBuilder With(Money money)
        {
            _money = money;
            return this;
        }
        
        public MoneyOperation Please()
        {
            return new MoneyOperation(_personId, _money);
        }
        
        public static implicit operator MoneyOperation(MoneyOperationBuilder builder)
        {
            return builder.Please();
        }
    }
}