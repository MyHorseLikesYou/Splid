using Splid.Domain.Models.Groups;
using System;

namespace Splid.Application.Commands.Persons
{
    public abstract class SavePersonCommand : GroupCommand
    {        
        public Guid PersonId { get; set; }
        public PersonInput Person { get; set; }
    }
}
