using MyApp.Core.Contracts;
using MyApp.Core.Domain;
using System;

namespace Splid.Domain.Main.Values
{
    public class Money : Value
    {
        public decimal Value { get; private set; }

        public Money(decimal value)
        {
            this.Value = value;
        }
    }
}
