using System;
using NUnit.Framework;
using Splid.Domain.Main.Tests.Builders.Groups.Entities;

namespace Splid.Domain.Main.Tests.Entities.Groups.GroupTests
{
    [TestFixture]
    public class Group_Change
    {
        [Test]
        public void ChangeGroup_NullGroupInput_ThrowArgumentNullException()
        {
            var group = GroupBuilder.New().Please();

            Assert.Throws<ArgumentNullException>(() => group.Change(null));
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void ChangeGroup_InvalidName_ThrowArgumentException(string name)
        {
            var group = GroupBuilder.New().Please();
            var groupInput = new GroupInput() { Name = name };

            Assert.Throws<ArgumentException>(() => group.Change(groupInput));
        }

        [Test]
        public void ChangeGroup_ValidArguments_DoesNotThrow()
        {
            var group = GroupBuilder.New().Please();
            var groupInput = new GroupInput() { Name = "test_group" };

            Assert.DoesNotThrow(() => group.Change(groupInput));
        }
    }
}
