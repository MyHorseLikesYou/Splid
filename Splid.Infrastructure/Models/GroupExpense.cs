using System;
using System.Collections.Generic;
using Splid.Domain.Main.Values;

namespace Splid.Infrastructure.Models
{
    internal sealed class GroupExpense
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public List<PersonMoneyOperation> PersonPayments { get; set; }
        public List<PersonMoneyOperation> PersonExpenses { get; set; }
        public DateTimeOffset Date { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
    }
}