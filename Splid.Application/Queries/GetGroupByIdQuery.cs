using MediatR;
using Splid.Application.ViewModels;
using System;

namespace Splid.Application.Queries
{
    public class GetGroupByIdQuery : IRequest<GroupViewModel>
    {
        public Guid GroupId { get; set; }
    }
}
