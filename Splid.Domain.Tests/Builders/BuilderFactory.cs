using Splid.Domain.Main.Tests.Builders.Groups.Entities;
using Splid.Domain.Main.Tests.Builders.Groups.Inputs;
using Splid.Domain.Main.Tests.Builders.Repositories;
using Splid.Domain.Main.Tests.Builders.Services;

namespace Splid.Domain.Main.Tests.Builders
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

        public PaymentRepositoryBuilder PaymentRepository()
        {
            return new PaymentRepositoryBuilder();
        }
        
        public GroupRepositoryBuilder GroupRepository()
        {
            return new GroupRepositoryBuilder();
        }

        public PaymentServiceBuilder PaymentService()
        {
            return new PaymentServiceBuilder();
        }
    }
}
