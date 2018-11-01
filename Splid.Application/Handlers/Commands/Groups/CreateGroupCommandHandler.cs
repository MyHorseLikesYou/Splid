using System;
using Splid.Application.Commands.Groups;
using Splid.Domain.Main.Services;
using System.Threading;
using System.Threading.Tasks;

namespace Splid.Application.Handlers.Commands.Groups
{
    public class CreateGroupCommandHandler 
    {
        private readonly GroupsService _groupsService;

        public CreateGroupCommandHandler(GroupsService groupsService)
        {
            _groupsService = groupsService ?? throw new ArgumentNullException(nameof(groupsService));
        }

        protected Task Handle(CreateGroupCommand createGroupCommand, CancellationToken cancellationToken)
        {
            if (createGroupCommand == null) 
                throw new ArgumentNullException(nameof(createGroupCommand));
            
            return Task.Run(() => _groupsService.CreateGroup(createGroupCommand.GroupId, createGroupCommand.Group), cancellationToken);
        }
    }
}
