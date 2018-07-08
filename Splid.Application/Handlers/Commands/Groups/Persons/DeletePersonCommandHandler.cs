using Splid.Application.Commands.Groups.Persons;
using Splid.Domain.Main.Services;
using System.Threading;
using System.Threading.Tasks;

namespace Splid.Application.Handlers.Commands.Groups.Persons
{
    public class DeletePersonCommandHandler : GroupCommandHandler<DeletePersonCommand>
    {
        protected DeletePersonCommandHandler(GroupsService groupsService)
            : base(groupsService)
        { }

        protected override Task Handle(DeletePersonCommand deletePersonCommand, CancellationToken cancellationToken)
        {
            return Task.Run(() => _groupsService.DeletePerson(deletePersonCommand.GroupId, deletePersonCommand.PersonId));
        }
    }
}
