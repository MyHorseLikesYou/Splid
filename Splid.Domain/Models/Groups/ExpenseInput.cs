using Splid.Domain.Main.Values;
using System;
using System.Collections.Generic;

namespace Splid.Domain.Models.Groups
{
    public class ExpenseInput
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public IDictionary<Guid, Money> By { get; set; }
        public IDictionary<Guid, Money> For { get; set; }
        public DateTime Date { get; set; }
    }
}
