using MediatR;
using Splid.Application.ViewModels;
using System;

namespace Splid.Application.Queries
{
    public class GetPaymentByIdQuery : IRequest<PaymentViewModel>
    {
        public Guid GroupId { get; set; }
        public Guid PaymentId { get; set; }
    }
}
