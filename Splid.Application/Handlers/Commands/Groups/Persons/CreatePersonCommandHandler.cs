using Splid.Application.Commands.Groups.Persons;
using Splid.Domain.Main.Services;
using System.Threading;
using System.Threading.Tasks;

namespace Splid.Application.Handlers.Commands.Groups.Persons
{
    public class CreatePersonCommandHandler : GroupCommandHandler<CreatePersonCommand>
    {
        protected CreatePersonCommandHandler(GroupsService groupsService)
            : base(groupsService)
        { }

        protected override Task Handle(CreatePersonCommand createPersonCommand, CancellationToken cancellationToken)
        {
            return Task.Run(() => _groupsService.AddPerson(createPersonCommand.GroupId, createPersonCommand.PersonId, createPersonCommand.Person));
        }
    }
}
