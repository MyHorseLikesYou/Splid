using Splid.Application.Commands.Groups.Persons;
using Splid.Domain.Main.Services;
using System.Threading;
using System.Threading.Tasks;

namespace Splid.Application.Handlers.Commands.Groups.Persons
{
    public class ChangePersonCommandHandler : GroupCommandHandler<ChangePersonCommand>
    {
        protected ChangePersonCommandHandler(GroupsService groupsService)
            : base(groupsService)
        { }

        protected override Task Handle(ChangePersonCommand changePersonCommand, CancellationToken cancellationToken)
        {
            return Task.Run(() => _groupsService.ChangePerson(changePersonCommand.GroupId, changePersonCommand.PersonId, changePersonCommand.Person));
        }
    }
}
