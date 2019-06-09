using Splid.Domain.Main.Interfaces.Repositories;

namespace Splid.Domain.Main.Tests.Builders.Repositories
{
    public class PaymentRepositoryBuilder : IBuilder<IPaymentRepository>
    {
        public IPaymentRepository Please()
        {
            throw new System.NotImplementedException();
        }

        public PaymentRepositoryBuilder WithPayments(params Payment[] payment)
        {
            throw new System.NotImplementedException();
        }
    }
}