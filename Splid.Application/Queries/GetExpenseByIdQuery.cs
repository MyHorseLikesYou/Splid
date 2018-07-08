using MediatR;
using Splid.Application.ViewModels;
using System;

namespace Splid.Application.Queries
{
    public class GetExpenseByIdQuery : IRequest<ExpenseViewModel>
    {
        public Guid GroupId { get; set; }
        public Guid ExpenseId { get; set; }        
    }
}
