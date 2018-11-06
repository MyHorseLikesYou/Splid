using System;
using NUnit.Framework;

namespace Splid.Domain.Main.Tests.Entities.Groups.GroupTests
{
    [TestFixture]
    public class Group_ChangePerson : BaseTest
    {
        [Test]
        public void ChangePerson_NullPersonInput_ArgumentNullException()
        {
            var personId = Guid.NewGuid();
            var group = New().Group()
                .HavePersonsWithIds(personId)
                .Build();

            Assert.Throws<ArgumentNullException>(() => group.ChangePerson(personId, null));
        }

        [Test]
        public void ChangePerson_HavePersonWithSameName_ThrowArgumentException()
        {
            var personToChangeId = Guid.NewGuid();
            var nameThatWillBeTheSame = "test_name";

            var group = New().Group()
                .HavePersonsWithIds(personToChangeId)
                .HavePersonsWithNames(nameThatWillBeTheSame)
                .Build();
            
            var personInput = New().PersonInput()
                .WithName(nameThatWillBeTheSame)
                .Build();

            Assert.Throws<ArgumentException>(() => group.AddPerson(personToChangeId, personInput));
        }

        [Test]
        public void ChangePerson_ValidArguments_DoesNotThrow()
        {
            var personToChangeId = Guid.NewGuid();
            var group = New().Group()
                .HavePersonsWithIds(personToChangeId)
                .Build();

            var personInput = New().PersonInput().Build();            

            Assert.DoesNotThrow(() => group.ChangePerson(personToChangeId, personInput));
        }
    }
}
