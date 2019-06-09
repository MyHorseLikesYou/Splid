namespace Splid.Domain.Main.Tests.Builders.Groups.Inputs
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

        public PersonInput Please()
        {
            return new PersonInput()
            {
                Name = _name
            };
        }
    }
}
