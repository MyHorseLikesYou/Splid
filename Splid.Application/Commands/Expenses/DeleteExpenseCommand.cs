using System;

namespace Splid.Application.Commands.Expenses
{
    public class DeleteExpenseCommand : GroupCommand
    {
        public Guid ExpenseId { get; set; }
    }
}
