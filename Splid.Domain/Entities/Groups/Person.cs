using MyApp.Core.Domain;
using System;

namespace Splid.Domain.Main.Entities.Groups
{
    public class Person : Entity
    {
        public Person(Guid id) : base(id)
        {
        }

        public string Name { get; }

        //public Person(string name)
        //{
        //    this.Name = name ?? throw new ArgumentException(nameof(Person.Name), "Имя участника группы не может быть пустым.");
        //}
    }
}
