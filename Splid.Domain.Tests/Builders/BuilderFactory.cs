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

        public GroupExpenseInputBuilder GroupExpenseInput()
        {
            return new GroupExpenseInputBuilder();
        }

        public PersonBuilder Person()
        {
            return new PersonBuilder();
        }

        public PersonInputBuilder PersonInput()
        {
            return new PersonInputBuilder();
        }

        public PaymentInputBuilder PaymentInput()
        {
            return new PaymentInputBuilder();
        }

        public PaymentBuilder Payment()
        {
            return new PaymentBuilder();
        }
    }
}
