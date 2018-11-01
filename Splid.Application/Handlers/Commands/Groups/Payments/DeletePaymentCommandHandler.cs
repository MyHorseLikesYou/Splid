using System;
using Splid.Application.Commands.Groups.Payments;
using Splid.Domain.Main.Services;
using System.Threading;
using System.Threading.Tasks;

namespace Splid.Application.Handlers.Commands.Groups.Payments
{
    public class DeletePaymentCommandHandler
    {
        private readonly PaymentService _paymentService;

        protected DeletePaymentCommandHandler(PaymentService paymentService)
        {
            _paymentService = paymentService ?? throw new ArgumentNullException(nameof(paymentService));
        }

        protected Task Handle(DeletePaymentCommand deletePaymentCommand, CancellationToken cancellationToken)
        {
            if (deletePaymentCommand == null) 
                throw new ArgumentNullException(nameof(deletePaymentCommand));
            
            return Task.Run(() => _paymentService.DeletePayment(deletePaymentCommand.PaymentId), cancellationToken);
        }
    }
}
