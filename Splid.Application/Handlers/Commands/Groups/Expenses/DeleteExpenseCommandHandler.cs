using Splid.Application.Commands.Groups.Expenses;
using Splid.Domain.Main.Services;
using System.Threading;
using System.Threading.Tasks;

namespace Splid.Application.Handlers.Commands.Groups.Expenses
{
    public class DeleteExpenseCommandHandler : GroupCommandHandler<DeleteExpenseCommand>
    {
        protected DeleteExpenseCommandHandler(GroupsService groupsService)
            : base(groupsService)
        { }

        protected override Task Handle(DeleteExpenseCommand deleteExpenseCommand, CancellationToken cancellationToken)
        {
            return Task.Run(() => _groupsService.DeleteExpense(deleteExpenseCommand.GroupId, deleteExpenseCommand.GroupId));
        }
    }
}
