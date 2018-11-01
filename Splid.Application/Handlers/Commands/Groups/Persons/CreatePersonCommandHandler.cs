using System;
using Splid.Application.Commands.Groups.Persons;
using Splid.Domain.Main.Services;
using System.Threading;
using System.Threading.Tasks;

namespace Splid.Application.Handlers.Commands.Groups.Persons
{
    public class CreatePersonCommandHandler 
    {
        private readonly GroupsService _groupsService;

        public CreatePersonCommandHandler(GroupsService groupsService)
        {
            _groupsService = groupsService ?? throw new ArgumentNullException(nameof(groupsService));
        }

        protected Task Handle(CreatePersonCommand createPersonCommand, CancellationToken cancellationToken)
        {
            if (createPersonCommand == null) 
                throw new ArgumentNullException(nameof(createPersonCommand));
            
            return Task.Run(() => _groupsService.AddPerson(createPersonCommand.GroupId, createPersonCommand.PersonId, createPersonCommand.Person), cancellationToken);
        }
    }
}
