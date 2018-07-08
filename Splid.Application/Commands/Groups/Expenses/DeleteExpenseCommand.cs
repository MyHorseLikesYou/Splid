using System;

namespace Splid.Application.Commands.Groups.Expenses
{
    public class DeleteExpenseCommand : GroupCommand
    {
        public Guid ExpenseId { get; set; }
    }
}
