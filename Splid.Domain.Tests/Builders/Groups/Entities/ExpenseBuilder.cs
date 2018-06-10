using Splid.Domain.Main.Entities.Groups;
using System;
using System.Collections.Generic;
using System.Text;

namespace Splid.Domain.Tests.Builders.Groups.Entities
{
    public class GroupExpenseBuilder : IBuilder<GroupExpense>
    {
        public GroupExpenseBuilder SetId(Guid expenseId)
        {
            throw new NotImplementedException();
        }

        public GroupExpenseBuilder Set(Person expenseByPerson, Person expenseForPerson, int v)
        {
            throw new NotImplementedException();
        }

        public GroupExpense Build()
        {
            throw new NotImplementedException();
        }

        public GroupExpenseBuilder WithFutureDate()
        {
            throw new NotImplementedException();
        }
    }
}
