using System;

namespace Splid.Application.Commands.Payments
{
    public class DeletePaymentCommand : GroupCommand
    {
        public Guid PaymentId { get; set; }
    }
}
