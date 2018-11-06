using System;
using NUnit.Framework;
using Splid.Domain.Main.Entities.Groups;

namespace Splid.Domain.Main.Tests.Entities.Groups.ExpenseTests
{
    [TestFixture]
    public class GroupExpense_Create : BaseTest
    {
        [Test]
        public void CreateGroupExpense_NullInput_ThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => GroupExpense.Create(Guid.NewGuid(), null));
        }

        [Test]
        public void CreateGroupExpense_ValidArguments_DoesNotThrow()
        {
            var groupExpenseInput = New().GroupExpenseInput().Build();

            Assert.DoesNotThrow(() => GroupExpense.Create(Guid.NewGuid(), groupExpenseInput));
        }
    }
}
