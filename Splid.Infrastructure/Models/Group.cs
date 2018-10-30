using System;
using System.Collections.Generic;

namespace Splid.Infrastructure.Models
{
    internal sealed class Group
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Person> Persons { get; set; }
        public List<Payment> Payments { get; set; }
        public List<GroupExpense> Expenses { get; set; }
    }
}