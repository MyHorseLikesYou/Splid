using System;
using Splid.Application.Commands.Groups.Persons;
using Splid.Domain.Main.Services;
using System.Threading;
using System.Threading.Tasks;

namespace Splid.Application.Handlers.Commands.Groups.Persons
{
    public class ChangePersonCommandHandler
    {
        private readonly GroupsService _groupsService;

        protected ChangePersonCommandHandler(GroupsService groupsService)
        {
            _groupsService = groupsService ?? throw new ArgumentNullException(nameof(groupsService));
        }

        protected Task Handle(ChangePersonCommand changePersonCommand, CancellationToken cancellationToken)
        {
            if (changePersonCommand == null) 
                throw new ArgumentNullException(nameof(changePersonCommand));
            
            return Task.Run(() => _groupsService.ChangePerson(changePersonCommand.GroupId, changePersonCommand.PersonId, changePersonCommand.Person), cancellationToken);
        }
    }
}
