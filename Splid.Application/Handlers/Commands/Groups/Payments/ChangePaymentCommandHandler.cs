using System;
using Splid.Application.Commands.Groups.Payments;
using Splid.Domain.Main.Services;
using System.Threading;
using System.Threading.Tasks;

namespace Splid.Application.Handlers.Commands.Groups.Payments
{
    public class ChangePaymentCommandHandler 
    {
        private readonly PaymentService _paymentService;

        protected ChangePaymentCommandHandler(PaymentService paymentService)
        {
            _paymentService = paymentService ?? throw new ArgumentNullException(nameof(paymentService));
        }

        protected Task Handle(ChangePaymentCommand changePaymentCommand, CancellationToken cancellationToken)
        {
            if (changePaymentCommand == null) 
                throw new ArgumentNullException(nameof(changePaymentCommand));
            
            return Task.Run(() => _paymentService.ChangePayment(changePaymentCommand.PaymentId, changePaymentCommand.Payment), cancellationToken);
        }
    }
}
