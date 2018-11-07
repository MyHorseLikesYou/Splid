using System;
using Splid.Domain.Main.Models;

namespace Splid.Application.Commands.Groups.Payments
{
    public abstract class SavePaymentCommand : GroupCommand
    {
        public Guid PaymentId { get; set; }
        public PaymentInput Payment { get; set; }
    }
}
