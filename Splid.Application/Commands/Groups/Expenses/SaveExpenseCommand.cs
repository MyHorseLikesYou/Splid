using System;
using Splid.Domain.Main.Models;

namespace Splid.Application.Commands.Groups.Expenses
{
    public abstract class SaveExpenseCommand : GroupCommand
    {
        public Guid ExpenseId { get; set; }
        public GroupExpenseInput Expense { get; set; }
    }
}
