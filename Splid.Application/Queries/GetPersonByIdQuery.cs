using MediatR;
using Splid.Application.ViewModels;
using System;

namespace Splid.Application.Queries
{
    public class GetPersonByIdQuery : IRequest<PersonViewModel>
    {
        public Guid GroupId { get; set; }
        public Guid PersonId { get; set; }
    }
}
