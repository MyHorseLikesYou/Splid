using NUnit.Framework;
using Splid.Domain.Tests.Builders.Groups.Entities;
using Splid.Domain.Tests.Builders.Groups.Inputs;
using System;

namespace Splid.Domain.Tests.Entities.Groups.GroupTests
{
    [TestFixture]
    public class Group_ChangePerson
    {
        [Test]
        public void ChangePerson_NullPersonInput_ArgumentNullException()
        {
            var personId = Guid.NewGuid();
            var group = GroupBuilder.New()
                .HavePersonsWithIds(personId)
                .Build();

            Assert.Throws<ArgumentNullException>(() => group.ChangePerson(personId, null));
        }

        [Test]
        public void ChangePerson_HavePersonWithSameName_ThrowArgumentException()
        {
            var personToChangeId = Guid.NewGuid();
            var nameThatWillBeTheSame = "test_name";

            var group = GroupBuilder.New()
                .HavePersonsWithIds(personToChangeId)
                .HavePersonsWithNames(nameThatWillBeTheSame)
                .Build();
            
            var personInput = PersonInputBuilder.New()
                .With(personToChangeId, nameThatWillBeTheSame)
                .Build();

            Assert.Throws<ArgumentException>(() => group.AddPerson(personToChangeId, personInput));
        }

        [Test]
        public void ChangePerson_ValidArguments_DoesNotThrow()
        {
            var personToChangeId = Guid.NewGuid();
            var group = GroupBuilder.New()
                .HavePersonsWithIds(personToChangeId)
                .Build();

            var personInput = PersonInputBuilder.New().Build();            

            Assert.DoesNotThrow(() => group.ChangePerson(personToChangeId, personInput));
        }
    }
}
