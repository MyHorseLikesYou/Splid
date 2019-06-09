using System;
using System.Linq;
using NUnit.Framework;
using Splid.Domain.Main.Tests.Builders;
using Splid.Domain.Main.Tests.Builders.Constants.Groups;

namespace Splid.Domain.Main.Tests.Entities.Groups.GroupTests
{
    [TestFixture]
    public class Group_AddPerson
    {
        [Test]
        public void When_NullInput_Then_ArgumentNullException()
        {
            var group = Create.Group.Please();

            Assert.Throws<ArgumentNullException>(() => group.AddPerson(Guid.NewGuid(), null));
        }

        [Test]
        public void When_GroupHasPersonWithSameName_Then_ThrowArgumentException()
        {
            var group = Create.Group.WithPerson(Persons.Ivan).Please();            
            var personInput = Create.PersonInput.WithName(Persons.Ivan.Name).Please();

            Assert.Throws<ArgumentException>(() => group.AddPerson(Guid.NewGuid(), personInput));
        }

        [Test]
        public void When_GroupHasSamePerson_Then_ThrowArgumentException()
        {
            var group = Create.Group.WithPerson(Persons.Ivan).Please();            
            var personInput = Create.PersonInput.Please();

            Assert.Throws<ArgumentException>(() => group.AddPerson(Persons.Ivan.Id, personInput));
        }
        
        [Test]
        public void When_NewPerson_Then_PersonIsAddedToGroup()
        {
            var group = Create.Group.Please();

            var personId = Guid.NewGuid();
            var personInput = Create.PersonInput.Please();

            group.AddPerson(personId, personInput);

            Assert.That(group.Persons, Contains.Item());
        }
    }
}
