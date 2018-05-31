using Splid.Domain.Models.Groups;

namespace Splid.Application.Commands.Expenses
{
    public abstract class SaveExpenseCommand : GroupCommand
    {                
        public ExpenseInput Expense { get; set; }
    }
}
