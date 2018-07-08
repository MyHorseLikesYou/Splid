using Splid.Application.Commands.Groups.Payments;
using Splid.Domain.Main.Services;
using System.Threading;
using System.Threading.Tasks;

namespace Splid.Application.Handlers.Commands.Groups.Payments
{
    public class DeletePaymentCommandHandler : GroupCommandHandler<DeletePaymentCommand>
    {
        protected DeletePaymentCommandHandler(GroupsService groupsService)
            : base(groupsService)
        { }

        protected override Task Handle(DeletePaymentCommand deletePaymentCommand, CancellationToken cancellationToken)
        {
            return Task.Run(() => _groupsService.DeletePayment(deletePaymentCommand.GroupId, deletePaymentCommand.PaymentId));
        }
    }
}
