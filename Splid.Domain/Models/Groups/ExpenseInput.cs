﻿using Splid.Domain.Main.Values;
using System;
using System.Collections.Generic;

namespace Splid.Domain.Models.Groups
{
    public class ExpenseInput
    {        
        public string Title { get; set; }
        public IEnumerable<PersonMoneyOperation> By { get; set; }
        public IEnumerable<PersonMoneyOperation> For { get; set; }
        public DateTimeOffset Date { get; set; }
    }
}
