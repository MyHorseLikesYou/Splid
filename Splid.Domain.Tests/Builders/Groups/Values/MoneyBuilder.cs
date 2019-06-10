using Splid.Domain.Main.Values;

namespace Splid.Domain.Main.Tests.Builders.Groups.Values
{
    public class MoneyBuilder : IBuilder<Money>
    {
        private decimal _amount;

        public Money Please()
        {
            return new Money(_amount);
        }
    }
}