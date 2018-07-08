using Splid.Application.Commands.Groups;
using Splid.Domain.Main.Services;
using System.Threading;
using System.Threading.Tasks;

namespace Splid.Application.Handlers.Commands.Groups
{
    public class CreateGroupCommandHandler : GroupCommandHandler<CreateGroupCommand>
    {
        protected CreateGroupCommandHandler(GroupsService groupsService)
            : base(groupsService)
        { }

        protected override Task Handle(CreateGroupCommand createGroupCommand, CancellationToken cancellationToken)
        {
            return Task.Run(() => _groupsService.ChangeGroup(createGroupCommand.GroupId, createGroupCommand.Group));
        }
    }
}
