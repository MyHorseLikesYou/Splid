using MediatR;
using Splid.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Splid.Application.Queries
{
    public class GetPersonByIdQuery : IRequest<PersonViewModel>
    {
        public Guid GroupId { get; set; }
        public Guid PersonId { get; set; }
    }
}
