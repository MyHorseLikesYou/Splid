using MediatR;
using Splid.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace Splid.Application.Queries
{
    public class GetExpensesByGroupIdQuery : IRequest<IEnumerable<ExpenseViewModel>>
    {
        public Guid GroupId { get; set; }
    }
}
