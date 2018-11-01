using System;
using Splid.Application.Commands.Groups.Expenses;
using Splid.Domain.Main.Services;
using System.Threading;
using System.Threading.Tasks;

namespace Splid.Application.Handlers.Commands.Groups.Expenses
{
    public class ChangeExpenseCommandHandler
    {
        private readonly GroupExpenseService _groupExpenseService;

        public ChangeExpenseCommandHandler(GroupExpenseService groupExpenseService)
        {
            _groupExpenseService = groupExpenseService ?? throw new ArgumentNullException(nameof(groupExpenseService));
        }

        protected Task Handle(ChangeExpenseCommand changeExpenseCommand, CancellationToken cancellationToken)
        {
            if (changeExpenseCommand == null) 
                throw new ArgumentNullException(nameof(changeExpenseCommand));
            
            return Task.Run(() => _groupExpenseService.ChangeExpense(changeExpenseCommand.ExpenseId, changeExpenseCommand.Expense), cancellationToken);
        }
    }
}
