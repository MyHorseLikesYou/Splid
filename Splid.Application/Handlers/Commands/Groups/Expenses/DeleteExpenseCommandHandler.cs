using System;
using Splid.Application.Commands.Groups.Expenses;
using Splid.Domain.Main.Services;
using System.Threading;
using System.Threading.Tasks;

namespace Splid.Application.Handlers.Commands.Groups.Expenses
{
    public class DeleteExpenseCommandHandler
    {
        private readonly GroupExpenseService _groupExpenseService;

        protected DeleteExpenseCommandHandler(GroupExpenseService groupExpenseService)
        {
            _groupExpenseService = groupExpenseService ?? throw new ArgumentNullException(nameof(groupExpenseService));
        }

        protected Task Handle(DeleteExpenseCommand deleteExpenseCommand, CancellationToken cancellationToken)
        {
            if (deleteExpenseCommand == null) 
                throw new ArgumentNullException(nameof(deleteExpenseCommand));
            
            return Task.Run(() => _groupExpenseService.DeleteExpense(deleteExpenseCommand.ExpenseId), cancellationToken);
        }
    }
}
