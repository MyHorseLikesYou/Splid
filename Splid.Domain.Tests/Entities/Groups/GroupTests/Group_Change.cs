using NUnit.Framework;
using Splid.Domain.Models.Groups;
using Splid.Domain.Tests.Builders.Groups.Entities;
using System;

namespace Splid.Domain.Tests.Entities.Groups.GroupTests
{
    [TestFixture]
    public class Group_Change
    {
        [Test]
        public void ChangeGroup_NullGroupInput_ThrowArgumentNullException()
        {
            var group = GroupBuilder.New().Build();

            Assert.Throws<ArgumentException>(() => group.Change(null));
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void ChangeGroup_InvalidName_ThrowArgumentException(string name)
        {
            var group = GroupBuilder.New().Build();
            var groupInput = new GroupInput() { Name = name };

            Assert.Throws<ArgumentException>(() => group.Change(groupInput));
        }

        [Test]
        public void ChangeGroup_ValidArguments_DoesNotThrow()
        {
            var group = GroupBuilder.New().Build();
            var groupInput = new GroupInput() { Name = "test_group" };

            Assert.DoesNotThrow(() => group.Change(groupInput));
        }
    }
}
