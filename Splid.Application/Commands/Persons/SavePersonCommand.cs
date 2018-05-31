using Splid.Domain.Models.Groups;

namespace Splid.Application.Commands.Persons
{
    public abstract class SavePersonCommand : GroupCommand
    {        
        public PersonInput Person { get; set; }
    }
}
