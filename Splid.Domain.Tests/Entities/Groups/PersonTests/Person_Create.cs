using NUnit.Framework;
using NUnit.Framework.Internal;
using Splid.Domain.Main.Entities.Groups;
using System;

namespace Splid.Domain.Tests.Entities.Groups.PersonTests
{
    [TestFixture]
    public class Person_Create : BaseTest
    {
        [Test]
        public void CreatePerson_NullInput_ThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => Person.Create(Guid.NewGuid(), null));
        }

        [Test]
        public void CreatePerson_ValidArguments_DoesNotThrow()
        {
            var personInput = New().PersonInput().Build();

            Assert.DoesNotThrow(() => Person.Create(Guid.NewGuid(), personInput));
        }
    }
}
