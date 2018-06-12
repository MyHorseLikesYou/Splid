using NUnit.Framework;
using Splid.Domain.Main.Entities.Groups;
using Splid.Domain.Tests.Builders.Groups.Entities;
using System;

namespace Splid.Domain.Tests.Entities.Groups.PersonTests
{
    [TestFixture]
    public class Person_Construct : BaseTest
    {
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void ConstructPerson_InvalidName_ThrowArgumentException(string name)
        {
            Assert.Throws<ArgumentException>(() => new Person(Guid.NewGuid(), name));
        }

        [Test]
        public void ConstructPerson_ValidArguments_DoesNotThrow()
        {
            Assert.DoesNotThrow(() => new Person(Guid.NewGuid(), PersonBuilder.GetDefaultName()));
        }
    }
}
