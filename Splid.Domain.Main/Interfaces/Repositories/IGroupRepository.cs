using MyApp.Core.Contracts;
using System;
using Splid.Domain.Main.Entities;

namespace Splid.Domain.Main.Interfaces.Repositories
{
    public interface IGroupRepository : IRepository<Group>
    {
        bool IsGroupExists(Guid groupId);
    }
}