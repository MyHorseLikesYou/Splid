using Splid.Domain.Models.Groups;

namespace Splid.Application.Commands.Groups
{
    public abstract class SaveGroupCommand : GroupCommand
    {
        public GroupInput Group { get; set; }
    }
}
