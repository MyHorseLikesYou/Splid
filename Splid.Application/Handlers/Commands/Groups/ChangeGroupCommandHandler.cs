using Splid.Application.Commands.Groups;
using Splid.Domain.Main.Services;
using System.Threading;
using System.Threading.Tasks;

namespace Splid.Application.Handlers.Commands.Groups
{
    public class ChangeGroupCommandHandler : GroupCommandHandler<ChangeGroupCommand>
    {
        protected ChangeGroupCommandHandler(GroupsService groupsService)
            : base(groupsService)
        { }

        protected override Task Handle(ChangeGroupCommand changeGroupCommand, CancellationToken cancellationToken)
        {
            return Task.Run(() => _groupsService.ChangeGroup(changeGroupCommand.GroupId, changeGroupCommand.Group));
        }
    }
}
