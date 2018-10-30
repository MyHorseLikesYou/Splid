using MyApp.Core.Contracts;
using Splid.Domain.Main.Entities.Groups;
using System;

namespace Splid.Domain.Main.Interfaces.Repositories
{
    public interface IGroupsRepository : IRepository<Group>
    {
        bool IsGroupExists(Guid groupId);
    }
}