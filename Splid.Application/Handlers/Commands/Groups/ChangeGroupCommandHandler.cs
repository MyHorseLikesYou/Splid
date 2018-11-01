using System;
using Splid.Application.Commands.Groups;
using Splid.Domain.Main.Services;
using System.Threading;
using System.Threading.Tasks;

namespace Splid.Application.Handlers.Commands.Groups
{
    public class ChangeGroupCommandHandler
    {
        private readonly GroupsService _groupsService;

        public ChangeGroupCommandHandler(GroupsService groupsService)            
        {
            _groupsService = groupsService ?? throw new ArgumentNullException(nameof(groupsService));
        }

        protected Task Handle(ChangeGroupCommand changeGroupCommand, CancellationToken cancellationToken)
        {
            if (changeGroupCommand == null) 
                throw new ArgumentNullException(nameof(changeGroupCommand));
            
            return Task.Run(() => _groupsService.ChangeGroup(changeGroupCommand.GroupId, changeGroupCommand.Group), cancellationToken);
        }
    }
}
