using MyApp.Core.Contracts;
using System;

namespace Splid.Application.Commands
{
    public class GroupCommand : ICommand
    {
        public Guid GroupId { get; set; }
        public Guid? AuthorId { get; set; }
    }
}
