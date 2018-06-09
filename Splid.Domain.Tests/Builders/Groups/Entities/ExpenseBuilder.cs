using Splid.Domain.Main.Entities.Groups;
using System;
using System.Collections.Generic;
using System.Text;

namespace Splid.Domain.Tests.Builders.Groups.Entities
{
    public class ExpenseBuilder : IBuilder<Expense>
    {
        public ExpenseBuilder SetId(Guid expenseId)
        {
            throw new NotImplementedException();
        }

        public ExpenseBuilder Set(Person expenseByPerson, Person expenseForPerson, int v)
        {
            throw new NotImplementedException();
        }

        public Expense Build()
        {
            throw new NotImplementedException();
        }

        public static ExpenseBuilder Create()
        {
            return new ExpenseBuilder();
        }
    }
}
