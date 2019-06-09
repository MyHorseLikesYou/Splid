using System;
using Splid.Domain.Main.Entities;
using Splid.Domain.Main.Models;

namespace Splid.Domain.Main.Tests.Builders.Constants.Groups
{
    public static class Persons
    {
        public static Person Ivan =>
            Create.Person
                .WithId(Guid.NewGuid())
                .WithName("Ivan")
                .Please();
    }
}