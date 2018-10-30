using System;
using Splid.Domain.Main.Values;

namespace Splid.Infrastructure.Models
{
    internal class PersonMoneyOperation
    {
        public Guid GroupExpenseId { get; set; }
        public Guid PersonId { get; set; }
        public decimal Amount { get; set; }
    }
}