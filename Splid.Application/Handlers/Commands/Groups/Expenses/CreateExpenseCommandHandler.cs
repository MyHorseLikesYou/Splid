using Splid.Application.Commands.Groups.Expenses;
using Splid.Domain.Main.Services;
using System.Threading;
using System.Threading.Tasks;

namespace Splid.Application.Handlers.Commands.Groups.Expenses
{
    public class CreateExpenseCommandHandler : GroupCommandHandler<CreateExpenseCommand>
    {
        protected CreateExpenseCommandHandler(GroupsService groupsService)
            : base(groupsService)
        { }

        protected override Task Handle(CreateExpenseCommand createExpenseCommand, CancellationToken cancellationToken)
        {
            return Task.Run(() => _groupsService.AddExpense(createExpenseCommand.GroupId, createExpenseCommand.ExpenseId, createExpenseCommand.Expense));
        }
    }
}
