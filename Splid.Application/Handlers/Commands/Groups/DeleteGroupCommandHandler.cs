using Splid.Application.Commands.Groups;
using Splid.Domain.Main.Services;
using System.Threading;
using System.Threading.Tasks;

namespace Splid.Application.Handlers.Commands.Groups
{
    public class DeleteGroupCommandHandler : GroupCommandHandler<DeleteGroupCommand>
    {
        protected DeleteGroupCommandHandler(GroupsService groupsService)
            : base(groupsService)
        { }

        protected override async Task Handle(DeleteGroupCommand deleteGroupCommand, CancellationToken cancellationToken)
        {
            await Task.Run(() => _groupsService.DeleteGroup(deleteGroupCommand.GroupId));
        }
    }
}
