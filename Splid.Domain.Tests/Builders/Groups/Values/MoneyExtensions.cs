using System;
using Splid.Domain.Main.Values;

namespace Splid.Domain.Main.Tests.Builders.Groups.Values
{
    public static class MoneyExtensions
    {
        public static MoneyOperationBuilder Of(this Money money, Guid personId)
        {
            return Create.MoneyOperation.Of(personId).With(money);
        }
        
        public static MoneyOperationBuilder OfAnyone(this Money money)
        {
            return Create.MoneyOperation.Of(Guid.NewGuid()).With(money);
        }
        
        public static MoneyOperationBuilder OfAnyoneElse(this Money money)
        {
            return Create.MoneyOperation.Of(Guid.NewGuid()).With(money);
        }
    }
}