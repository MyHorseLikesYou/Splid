using Splid.Domain.Models.Groups;
using System.Collections.Generic;

namespace Splid.Application.Commands.Groups
{
    public class CreateGroupCommand : SaveGroupCommand
    {
        public IEnumerable<PersonInput> Persons { get; set; }
    }
}
