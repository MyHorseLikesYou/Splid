using System;
using System.Collections.Generic;
using System.Linq;
using MyApp.Core.Contracts;
using MyApp.Core.Domain;
using Splid.Domain.Main.Models;

namespace Splid.Domain.Main.Entities
{
    public sealed class Group : Entity, IAgregateRoot
    {
        private string _name;
        private List<Person> _persons;

        public Group(Guid groupId, string name, IEnumerable<Person> persons)
            : base(groupId)
        {
            ValidateArgumentForName(name);
            ValidateArgumentForPersons(persons);
            ValidatePersonsNotHaveDuplicateName(persons);
            
            _name = name;
            _persons = persons.ToList();            
        }

        public string Name => _name;

        public IReadOnlyCollection<Person> Persons => _persons;

        public void Change(GroupInput groupInput)
        {
            if (groupInput == null)
                throw new ArgumentNullException();

            ValidateArgumentForName(groupInput.Name);

            _name = groupInput.Name;
        }

        public void AddPerson(Guid personId, PersonInput personInput)
        {
            if (personInput == null)
                throw new ArgumentNullException(nameof(personInput));

            var personById = this.GetPersonById(personId);
            if (personById != null)
                throw new ArgumentException($"Участник c Id {personId} уже есть в группе.");

            var personByName = this.GetPersonByName(personInput.Name);
            if (personByName != null)
                throw new ArgumentException($"Участник c именем {personInput.Name} уже есть в группе.");

            var personToAdd = Person.Create(personId, personInput);
            _persons.Add(personToAdd);
        }

        public void ChangePerson(Guid personId, PersonInput personInput)
        {
            if (personInput == null)
                throw new ArgumentNullException(nameof(personInput));

            var personByName = this.GetPersonByName(personInput.Name);
            if (personByName != null && personByName.Id != personId)
                throw new ArgumentException($"Участник c именем {personInput.Name} уже есть в группе.");

            var personToChange = personByName ?? this.GetPersonById(personId);
            if (personToChange == null)
                throw new ArgumentException($"Участника c Id {personId} нет в группе.");

            personToChange.Change(personInput);
        }

        public void DeletePerson(Guid personId)
        {
            var person = this.GetPersonById(personId);
            if (person == null)
                throw new ArgumentException($"Участника c Id {personId} нет в группе.");

            _persons.Remove(person);
        }
        
        public bool HasPersonWithSameId(Guid personId) => _persons.Any(p => p.Id == personId);

        private Person GetPersonById(Guid personId) => _persons.SingleOrDefault(p => p.Id == personId);

        private Person GetPersonByName(string personName) => _persons.SingleOrDefault(p => p.Name == personName);                

        private void ValidatePersonsNotHaveDuplicateName(IEnumerable<Person> persons)
        {
            var personsHaveDuplicatesByName = persons
                .GroupBy(p => p.Name)
                .Select(personsByName => personsByName.Count())
                .Any(countByName => countByName > 1);

            if (personsHaveDuplicatesByName)
                throw new ArgumentException();
        }

        private static void ValidateArgumentForName(string name)
        {
            if (String.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Имя группы не может быть пустым.");
        }

        private static void ValidateArgumentForPersons(IEnumerable<Person> persons)
        {
            if (persons == null)
                throw new ArgumentNullException(nameof(persons));
        }

        public static Group Create(Guid groupId, GroupInput groupInput)
        {
            if (groupInput == null)
                throw new ArgumentNullException(nameof(groupInput));

            return new Group(groupId, groupInput.Name, new List<Person>());
        }
    }
}