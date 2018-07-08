using Splid.Application.Commands.Groups.Payments;
using Splid.Domain.Main.Services;
using System.Threading;
using System.Threading.Tasks;

namespace Splid.Application.Handlers.Commands.Groups.Payments
{
    public class ChangePaymentCommandHandler : GroupCommandHandler<ChangePaymentCommand>
    {
        protected ChangePaymentCommandHandler(GroupsService groupsService)
            : base(groupsService)
        { }

        protected override Task Handle(ChangePaymentCommand changePaymentCommand, CancellationToken cancellationToken)
        {
            return Task.Run(() => _groupsService.ChangePayment(changePaymentCommand.GroupId, changePaymentCommand.PaymentId, changePaymentCommand.Payment));
        }
    }
}
