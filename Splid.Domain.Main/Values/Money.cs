using MyApp.Core.Domain;

namespace Splid.Domain.Main.Values
{
    public class Money : Value
    {
        public decimal Value { get; }

        public Money(decimal value)
        {
            Value = value;
        }
    }
}
