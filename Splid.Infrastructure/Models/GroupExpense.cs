using System;
using System.Collections.Generic;

namespace Splid.Infrastructure.Models
{
    internal sealed class GroupExpense
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public List<PersonMoneyOperation> Payments { get; set; }
        public List<PersonMoneyOperation> Expenses { get; set; }
        public DateTimeOffset Date { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
    }
}