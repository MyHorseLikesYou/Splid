using System;
using MyApp.Core.Contracts;
using Splid.Domain.Main.Entities.Groups;

namespace Splid.Domain.Main.Interfaces.Repositories
{
    public interface IPaymentRepository : IRepository<Payment>
    {
        bool IsPaymentExists(Guid paymentId);
    }
}