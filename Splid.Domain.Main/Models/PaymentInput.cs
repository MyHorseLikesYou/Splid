using System;
using Splid.Domain.Main.Values;

namespace Splid.Domain.Main.Models
{
    public class PaymentInput
    {       
        public Guid GroupId { get; set; }
        public Guid SenderId { get; set; }
        public Guid RecipientId { get; set; }
        public Money Amount { get; set; }
        public DateTimeOffset Date { get; set; }
    }
}
