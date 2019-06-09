using System;
using Splid.Domain.Main.Entities;

namespace Splid.Domain.Main.Tests.Builders.Groups.Entities
{
    public class PersonBuilder : IBuilder<Person>
    {
        private Guid _id;
        private string _name;

        public PersonBuilder WithId(Guid id)
        {
            _id = id;
            return this;
        }
        
        public PersonBuilder WithName(string name)
        {
            _name = name;
            return this;
        }
        
        public Person Please()
        {
            return new Person(_id, _name);
        }
    }
}
