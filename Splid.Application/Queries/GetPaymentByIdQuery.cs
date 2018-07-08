using MediatR;
using Splid.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Splid.Application.Queries
{
    public class GetPaymentByIdQuery : IRequest<PaymentViewModel>
    {
        public Guid GroupId { get; set; }
        public Guid PaymentId { get; set; }
    }
}
