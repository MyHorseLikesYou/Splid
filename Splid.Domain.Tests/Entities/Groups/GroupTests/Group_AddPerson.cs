using System;
using System.Linq;
using NUnit.Framework;
using Splid.Domain.Main.Tests.Builders.Groups.Entities;

namespace Splid.Domain.Main.Tests.Entities.Groups.GroupTests
{
    [TestFixture]
    public class Group_AddPerson : BaseTest
    {
        [Test]
        public void AddPerson_NullPersonInput_ArgumentNullException()
        {
            var group = GroupBuilder.New().Build();

            Assert.Throws<ArgumentNullException>(() => group.AddPerson(Guid.NewGuid(), null));
        }

        [Test]
        public void AddPerson_HavePersonWithSameName_ThrowArgumentException()
        {
            var personName = "test_name";
            var group = New().Group().HavePersonsWithNames(personName).Build();            
            var personInput = New().PersonInput().WithName(personName).Build();

            Assert.Throws<ArgumentException>(() => group.AddPerson(Guid.NewGuid(), personInput));
        }

        [Test]
        public void AddPerson_ValidArguments_GroupHasPerson()
        {
            var group = New().Group().Build();

            var personId = Guid.NewGuid();
            var personInput = New().PersonInput().Build();

            group.AddPerson(personId, personInput);

            Assert.That(group.Persons.Any(e => e.Id == personId));
        }
    }
}
