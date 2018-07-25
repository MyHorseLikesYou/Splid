﻿using Splid.Domain.Main.Models.Groups;
using System;

namespace Splid.Application.Commands.Groups.Persons
{
    public abstract class SavePersonCommand : GroupCommand
    {        
        public Guid PersonId { get; set; }
        public PersonInput Person { get; set; }
    }
}