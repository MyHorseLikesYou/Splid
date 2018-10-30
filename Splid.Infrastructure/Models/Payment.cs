using System;
using Splid.Domain.Main.Values;

namespace Splid.Infrastructure.Models
{
    internal sealed class Payment
    {
        public Guid Id { get; set; }        
        public Guid SenderId { get; set; }
        public Guid RecipientId { get; set; }
        public decimal Amount { get; set; }
        public DateTimeOffset Date { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
    }
}