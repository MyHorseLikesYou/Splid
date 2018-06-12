using Splid.Domain.Main.Entities.Groups;
using System;

namespace Splid.Domain.Tests.Builders.Groups.Entities
{
    public class PersonBuilder : IBuilder<Person>
    {
        private const string defaultName = "test_person";

        private Guid _id;
        private string _name;

        public PersonBuilder()
        {
            _id = Guid.NewGuid();
            _name = defaultName;
        }

        public Person Build()
        {
            return new Person(_id, _name);
        }

        public static string GetDefaultName()
        {
            return defaultName;
        }
    }
}
