using System;
using Splid.Application.Commands.Groups;
using Splid.Domain.Main.Services;
using System.Threading;
using System.Threading.Tasks;

namespace Splid.Application.Handlers.Commands.Groups
{
    public class DeleteGroupCommandHandler 
    {
        private readonly GroupsService _groupsService;

        public DeleteGroupCommandHandler(GroupsService groupsService)
        {
            _groupsService = groupsService ?? throw new ArgumentNullException(nameof(groupsService));
        }

        protected async Task Handle(DeleteGroupCommand deleteGroupCommand, CancellationToken cancellationToken)
        {
            if (deleteGroupCommand == null) 
                throw new ArgumentNullException(nameof(deleteGroupCommand));
            
            await Task.Run(() => _groupsService.DeleteGroup(deleteGroupCommand.GroupId), cancellationToken);
        }
    }
}
