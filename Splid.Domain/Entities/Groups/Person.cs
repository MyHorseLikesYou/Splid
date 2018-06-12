using MyApp.Core.Domain;
using Splid.Domain.Models.Groups;
using System;

namespace Splid.Domain.Main.Entities.Groups
{
    public class Person : Entity
    {
        public string Name { get; }

        public Person(Guid id, string name) 
            : base(id)
        {
            this.Name = name ?? throw new ArgumentException(nameof(Person.Name), "Имя участника группы не может быть пустым.");
        }        

        public void Change(PersonInput personInput)
        {
            throw new NotImplementedException();
        }

        public static Person Create(Guid personId, PersonInput personInput)
        {
            throw new NotImplementedException();
        }
    }
}
