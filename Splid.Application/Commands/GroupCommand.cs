using MediatR;
using MyApp.Core.Contracts;
using MyApp.Core.Models;
using System;

namespace Splid.Application.Commands
{
    public class GroupCommand : IRequest<CommandResult>
    {
        public Guid GroupId { get; set; }
        public Guid? AuthorId { get; set; }
    }
}
