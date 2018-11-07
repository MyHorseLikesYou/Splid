using Splid.Domain.Main.Models;

namespace Splid.Application.Commands.Groups
{
    public abstract class SaveGroupCommand : GroupCommand
    {
        public GroupInput Group { get; set; }
    }
}
