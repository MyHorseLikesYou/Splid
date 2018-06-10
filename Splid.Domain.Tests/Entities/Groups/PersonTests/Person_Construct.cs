using NUnit.Framework;
using Splid.Domain.Main.Entities.Groups;
using System;

namespace Splid.Domain.Tests.Entities.Groups.PersonTests
{
    [TestFixture]
    public class Person_Construct
    {
        [Test]
        public void ConstructPerson_InvalidId_ThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new Person(Guid.Empty, "test_name"));
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void ConstructPerson_InvalidName_ThrowArgumentException(string name)
        {
            Assert.Throws<ArgumentException>(() => new Person(Guid.NewGuid(), name));
        }
    }
}
