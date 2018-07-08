using Splid.Application.Commands.Groups.Payments;
using Splid.Domain.Main.Services;
using System.Threading;
using System.Threading.Tasks;

namespace Splid.Application.Handlers.Commands.Groups.Payments
{
    public class CreatePaymentCommandHandler : GroupCommandHandler<CreatePaymentCommand>
    {
        protected CreatePaymentCommandHandler(GroupsService groupsService)
            : base(groupsService)
        { }

        protected override Task Handle(CreatePaymentCommand createPaymentCommand, CancellationToken cancellationToken)
        {
            return Task.Run(() => _groupsService.AddPayment(createPaymentCommand.GroupId, createPaymentCommand.PaymentId, createPaymentCommand.Payment));
        }
    }
}
