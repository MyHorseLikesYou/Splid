﻿using Splid.Domain.Main.Values;
using System;
using System.Collections.Generic;

namespace Splid.Domain.Main.Models.Groups
{
    public class ExpenseInput
    {     
        public Guid GroupId { get; set; }
        public string Title { get; set; }
        public List<PersonMoneyOperation> Payments { get; set; }
        public List<PersonMoneyOperation> Expenses { get; set; }
        public DateTimeOffset Date { get; set; }
    }
}