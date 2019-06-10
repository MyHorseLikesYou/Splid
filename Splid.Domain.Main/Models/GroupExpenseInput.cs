using System;
using System.Collections.Generic;
using Splid.Domain.Main.Values;

namespace Splid.Domain.Main.Models
{
    public class GroupExpenseInput
    {
        public string Title { get; set; }
        public List<MoneyOperation> Payments { get; set; }
        public List<MoneyOperation> Expenses { get; set; }
        public DateTimeOffset Date { get; set; }
    }
}