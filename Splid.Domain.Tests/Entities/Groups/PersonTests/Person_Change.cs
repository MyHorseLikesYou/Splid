using NUnit.Framework;
using Splid.Domain.Tests.Builders;
using System;

namespace Splid.Domain.Tests.Entities.Groups.PersonTests
{
    [TestFixture]
    public class Person_Change
    {
        [Test]
        public void Change_NullInput_ThrowArgumentNullException()
        {
            var person = New().Person().Build();

            Assert.Throws<ArgumentNullException>(() => person.Change(null));
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void Change_InvalidName_ThrowArgumentException(string name)
        {
            var person = New().Person().Build();
            var personInput = New().PersonInput()
                .WithName(name)
                .Build();

            Assert.Throws<ArgumentException>(() => person.Change(personInput));
        }

        [Test]
        public void Change_ValidInput_DoesNotThrow()
        {
            var person = New().Person().Build();
            var personInput = New().PersonInput().Build();

            Assert.DoesNotThrow(() => person.Change(personInput));
        }

        private BuilderFactory New()
        {
            return new BuilderFactory();
        }
    }
}
