using Splid.Domain.Models.Groups;
using System;

namespace Splid.Application.Commands.Payments
{
    public abstract class SavePaymentCommand : GroupCommand
    {
        public Guid PaymentId { get; set; }
        public PaymentInput Payment { get; set; }
    }
}
