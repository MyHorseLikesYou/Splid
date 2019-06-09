using Splid.Domain.Main.Interfaces.Repositories;
using Splid.Domain.Main.Services;

namespace Splid.Domain.Main.Tests.Builders.Services
{
    public class PaymentServiceBuilder : IBuilder<PaymentService>
    {
        public PaymentService Please()
        {
            throw new System.NotImplementedException();
        }

        public PaymentServiceBuilder With(IPaymentRepository paymentRepository, IGroupRepository groupRepository)
        {
            throw new System.NotImplementedException();
        }
    }
}