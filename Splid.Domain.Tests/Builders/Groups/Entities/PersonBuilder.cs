using Splid.Domain.Main.Entities.Groups;
using Splid.Domain.Models.Groups;
using System;
using System.Collections.Generic;
using System.Text;

namespace Splid.Domain.Tests.Builders.Groups.Entities
{
    public class PersonBuilder : IBuilder<Person>
    {
        public Person Build()
        {
            throw new NotImplementedException();
        }

        public static PersonBuilder Create()
        {
            return new PersonBuilder();
        }
    }
}
