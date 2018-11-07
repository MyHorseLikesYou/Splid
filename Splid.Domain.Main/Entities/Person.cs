using System;
using MyApp.Core.Domain;
using Splid.Domain.Main.Models;

namespace Splid.Domain.Main.Entities
{
    public class Person : Entity
    {
        public string Name { get; private set; }

        public Person(Guid id, string name) 
            : base(id)
        {
            ValidateName(name);

            this.Name = name;
        }        

        public void Change(PersonInput personInput)
        {
            if (personInput == null)
                throw new ArgumentNullException();

            ValidateName(personInput.Name);

            this.Name = personInput.Name;
        }

        private static void ValidateName(string name)
        {
            if (String.IsNullOrWhiteSpace(name))
                throw new ArgumentException(nameof(Person.Name), "Имя участника группы не может быть пустым.");
        }

        public static Person Create(Guid personId, PersonInput personInput)
        {
            if (personInput == null)
                throw new ArgumentNullException();

            return new Person(personId, personInput.Name);
        }
    }
}
