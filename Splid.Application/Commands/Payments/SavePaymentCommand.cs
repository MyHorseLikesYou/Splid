using Splid.Domain.Models.Groups;

namespace Splid.Application.Commands.Payments
{
    public abstract class SavePaymentCommand : GroupCommand
    {
        public PaymentInput Payment { get; set; }
    }
}
