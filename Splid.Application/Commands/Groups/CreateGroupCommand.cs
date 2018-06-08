using Splid.Domain.Models.Groups;
using System;
using System.Collections.Generic;

namespace Splid.Application.Commands.Groups
{
    public class CreateGroupCommand : SaveGroupCommand
    {
        public IDictionary<Guid, PersonInput> Persons { get; set; }
    }
}
