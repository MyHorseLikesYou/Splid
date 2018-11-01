using System;
using Splid.Application.Commands.Groups.Payments;
using Splid.Domain.Main.Services;
using System.Threading;
using System.Threading.Tasks;

namespace Splid.Application.Handlers.Commands.Groups.Payments
{
    public class CreatePaymentCommandHandler
    {
        private readonly PaymentService _paymentService;

        protected CreatePaymentCommandHandler(PaymentService paymentService)
        {
            _paymentService = paymentService ?? throw new ArgumentNullException(nameof(paymentService));
        }

        protected Task Handle(CreatePaymentCommand createPaymentCommand, CancellationToken cancellationToken)
        {
            if (createPaymentCommand == null) 
                throw new ArgumentNullException(nameof(createPaymentCommand));
            
            return Task.Run(() => _paymentService.AddPayment(createPaymentCommand.PaymentId, createPaymentCommand.GroupId, createPaymentCommand.Payment), cancellationToken);
        }
    }
}
