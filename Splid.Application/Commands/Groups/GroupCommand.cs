using MediatR;
using MyApp.Core.Models;
using System;

namespace Splid.Application.Commands.Groups
{
    public class GroupCommand : IRequest
    {
        public Guid GroupId { get; set; }        
    }
}
