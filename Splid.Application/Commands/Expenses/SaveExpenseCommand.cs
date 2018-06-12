using Splid.Domain.Models.Groups;
using System;

namespace Splid.Application.Commands.Expenses
{
    public abstract class SaveExpenseCommand : GroupCommand
    {                
        public Guid ExpenseId { get; set; }
        public GroupExpenseInput Expense { get; set; }
    }
}
