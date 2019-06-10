using Splid.Domain.Main.Values;

namespace Splid.Domain.Main.Tests.Builders.Groups.Values
{
    public static class MoneyBuilder
    {
        public static Money Dollars(this int amount) => new Money(amount);
        public static Money Dollars(this decimal amount) => new Money(amount);
    }
}