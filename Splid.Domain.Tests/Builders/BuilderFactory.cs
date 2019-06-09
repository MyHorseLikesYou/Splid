using Splid.Domain.Main.Tests.Builders.Groups.Entities;
using Splid.Domain.Main.Tests.Builders.Groups.Inputs;
using Splid.Domain.Main.Tests.Builders.Repositories;
using Splid.Domain.Main.Tests.Builders.Services;

namespace Splid.Domain.Main.Tests.Builders
{
    public static class Create
    {
        public static GroupBuilder Group => new GroupBuilder();
        public static GroupExpenseBuilder GroupExpense => new GroupExpenseBuilder();
        public static GroupExpenseInputBuilder GroupExpenseInput => new GroupExpenseInputBuilder();
        public static PersonBuilder Person => new PersonBuilder();
        public static PersonInputBuilder PersonInput => new PersonInputBuilder();
        public static PaymentInputBuilder PaymentInput => new PaymentInputBuilder();
        public static PaymentBuilder Payment => new PaymentBuilder();
        public static PaymentRepositoryBuilder PaymentRepository => new PaymentRepositoryBuilder();
        public static GroupRepositoryBuilder GroupRepository => new GroupRepositoryBuilder();
        public static PaymentServiceBuilder PaymentService => new PaymentServiceBuilder();
    }
}
