using Splid.Domain.Main.Entities.Groups;
using Splid.Domain.Main.Interfaces.Repositories;
using Splid.Domain.Main.Tests.Builders.Groups.Entities;

namespace Splid.Domain.Main.Tests.Builders.Repositories
{
    public class PaymentRepositoryBuilder : IBuilder<IPaymentRepository>
    {
        public IPaymentRepository Build()
        {
            throw new System.NotImplementedException();
        }

        public PaymentRepositoryBuilder WithPayments(params Payment[] payment)
        {
            throw new System.NotImplementedException();
        }
    }
}