﻿using System;

namespace Splid.Application.Commands.Persons
{
    public class DeletePersonCommand : GroupCommand
    {
        public Guid PersonId { get; set; }
    }
}
