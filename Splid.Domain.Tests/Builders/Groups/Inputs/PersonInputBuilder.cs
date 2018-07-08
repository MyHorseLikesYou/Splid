using Splid.Domain.Main.Models.Groups;

namespace Splid.Domain.Tests.Builders.Groups.Inputs
{
    public class PersonInputBuilder : IBuilder<PersonInput>
    {
        private string _name;

        public PersonInputBuilder()
        {
            _name = "person_name";
        }

        public PersonInputBuilder WithName(string name)
        {
            _name = name;
            return this;
        }

        public PersonInput Build()
        {
            return new PersonInput()
            {
                Name = _name
            };
        }
    }
}
