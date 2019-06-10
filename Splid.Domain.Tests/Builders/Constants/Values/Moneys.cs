using Splid.Domain.Main.Values;

namespace Splid.Domain.Main.Tests.Builders.Constants.Values
{
    public static class Dollars
    {
        public static Money Amount(decimal amount) => new Money(amount);
    }
}