using System;
using Splid.Application.Commands.Groups.Expenses;
using Splid.Domain.Main.Services;
using System.Threading;
using System.Threading.Tasks;

namespace Splid.Application.Handlers.Commands.Groups.Expenses
{
    public class CreateExpenseCommandHandler
    {
        private readonly GroupExpenseService _groupExpenseService;

        protected CreateExpenseCommandHandler(GroupExpenseService groupExpenseService)
        {
            _groupExpenseService = groupExpenseService ?? throw new ArgumentNullException(nameof(groupExpenseService));
        }

        protected Task Handle(CreateExpenseCommand createExpenseCommand, CancellationToken cancellationToken)
        {
            if (createExpenseCommand == null) 
                throw new ArgumentNullException(nameof(createExpenseCommand));
            
            return Task.Run(() => _groupExpenseService.Create(createExpenseCommand.ExpenseId, createExpenseCommand.GroupId, createExpenseCommand.Expense), cancellationToken);
        }
    }
}
