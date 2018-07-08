using System;

namespace Splid.Application.Commands.Groups.Payments
{
    public class DeletePaymentCommand : GroupCommand
    {
        public Guid PaymentId { get; set; }
    }
}
