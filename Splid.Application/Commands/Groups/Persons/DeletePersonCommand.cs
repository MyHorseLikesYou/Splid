using System;

namespace Splid.Application.Commands.Groups.Persons
{
    public class DeletePersonCommand : GroupCommand
    {
        public Guid PersonId { get; set; }
    }
}
