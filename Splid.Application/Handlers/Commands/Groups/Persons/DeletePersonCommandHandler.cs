using System;
using Splid.Application.Commands.Groups.Persons;
using Splid.Domain.Main.Services;
using System.Threading;
using System.Threading.Tasks;

namespace Splid.Application.Handlers.Commands.Groups.Persons
{
    public class DeletePersonCommandHandler
    {
        private readonly GroupsService _groupsService;

        public DeletePersonCommandHandler(GroupsService groupsService)
        {
            _groupsService = groupsService ?? throw new ArgumentNullException(nameof(groupsService));
        }

        protected Task Handle(DeletePersonCommand deletePersonCommand, CancellationToken cancellationToken)
        {
            if (deletePersonCommand == null) 
                throw new ArgumentNullException(nameof(deletePersonCommand));
            
            return Task.Run(() => _groupsService.DeletePerson(deletePersonCommand.GroupId, deletePersonCommand.PersonId), cancellationToken);
        }
    }
}
