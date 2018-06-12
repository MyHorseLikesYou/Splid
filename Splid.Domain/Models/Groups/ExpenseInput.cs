using Splid.Domain.Main.Values;
using System;
using System.Collections.Generic;

namespace Splid.Domain.Models.Groups
{
    public class GroupExpenseInput
    {        
        public string Title { get; set; }
        public List<PersonMoneyOperation> Payments { get; set; }
        public List<PersonMoneyOperation> Expenses { get; set; }
        public DateTimeOffset Date { get; set; }
    }
}
