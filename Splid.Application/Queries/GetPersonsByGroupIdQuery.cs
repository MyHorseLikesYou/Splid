using MediatR;
using Splid.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Splid.Application.Queries
{
    public class GetPersonsByGroupIdQuery : IRequest<IEnumerable<PersonViewModel>>
    {
        public Guid GroupId { get; set; }
    }
}
