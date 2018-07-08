using NUnit.Framework;
using NUnit.Framework.Internal;
using Splid.Domain.Main.Entities.Groups;
using Splid.Domain.Main.Models.Groups;
using System;

namespace Splid.Domain.Tests.Entities.Groups.GroupTests
{
    [TestFixture]
    public class Group_Create
    {
        [Test]
        public void CreateGroup_NullGroupInput_ThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => Group.Create(Guid.NewGuid(), null));
        }

        [Test]
        public void CreateGroup_ValidArguments_NotNull()
        {
            var groupInput = new GroupInput()
            {                
                Name = "test_group",
            };

            var group = Group.Create(Guid.NewGuid(), groupInput);

            Assert.NotNull(group);
            Assert.AreEqual(groupInput.Name, group.Name);
        }
    }
}
