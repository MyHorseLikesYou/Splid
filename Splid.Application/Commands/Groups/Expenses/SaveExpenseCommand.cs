using Splid.Domain.Main.Models.Groups;
using System;

namespace Splid.Application.Commands.Groups.Expenses
{
    public abstract class SaveExpenseCommand : GroupCommand
    {
        public Guid ExpenseId { get; set; }
        public GroupExpenseInput Expense { get; set; }
    }
}
