using Splid.Domain.Main.Values;
using System;

namespace Splid.Domain.Models.Groups
{
    public class PaymentInput
    {
        public Guid Id { get; set; }
        public Guid PersonFromId { get; set; }
        public Guid PersonToId { get; set; }
        public Money Amount { get; set; }
        public DateTime Date { get; set; }
    }
}
