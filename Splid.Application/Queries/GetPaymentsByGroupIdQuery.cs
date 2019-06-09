using MediatR;
using Splid.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace Splid.Application.Queries
{
    public class GetPaymentsByGroupIdQuery : IRequest<IEnumerable<PaymentViewModel>>
    {
        public Guid GroupId { get; set; }
    }
}
