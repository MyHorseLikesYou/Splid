using System;
using Splid.Domain.Tests.Builders.Groups.Entities;
using Splid.Domain.Tests.Builders.Groups.Inputs;

namespace Splid.Domain.Tests.Builders
{
    public class BuilderFactory
    {
        public GroupBuilder Group()
        {
            return new GroupBuilder();
        }

        public GroupExpenseBuilder GroupExpense()
        {
            return new GroupExpenseBuilder();
        }

        public ExpenseInputBuilder GroupExpenseInput()
        {
            return new ExpenseInputBuilder();
        }

        public PersonBuilder Person()
        {
            throw new NotImplementedException();
        }

        public PersonInputBuilder PersonInput()
        {
            throw new NotImplementedException();
        }

        public PaymentInputBuilder PaymentInput()
        {
            return new PaymentInputBuilder();
        }
    }
}
