using Splid.Domain.Main.Values;
using System;

namespace Splid.Domain.Main.Models.Groups
{
    public class PaymentInput
    {       
        public Guid GroupId { get; set; }
        public Guid PersonById { get; set; }
        public Guid PersonForId { get; set; }
        public Money Amount { get; set; }
        public DateTimeOffset Date { get; set; }
    }
}
