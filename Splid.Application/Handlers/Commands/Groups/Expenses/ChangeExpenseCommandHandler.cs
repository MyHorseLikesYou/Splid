using Splid.Application.Commands.Groups.Expenses;
using Splid.Domain.Main.Services;
using System.Threading;
using System.Threading.Tasks;

namespace Splid.Application.Handlers.Commands.Groups.Expenses
{
    public class ChangeExpenseCommandHandler : GroupCommandHandler<ChangeExpenseCommand>
    {
        protected ChangeExpenseCommandHandler(GroupsService groupsService)
            : base(groupsService)
        { }

        protected override Task Handle(ChangeExpenseCommand changeExpenseCommand, CancellationToken cancellationToken)
        {
            return Task.Run(() => _groupsService.ChangeExpense(changeExpenseCommand.GroupId, changeExpenseCommand.ExpenseId, changeExpenseCommand.Expense));
        }
    }
}
