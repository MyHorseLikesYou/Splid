using System;
using System.Collections.Generic;
using MyApp.Core.Contracts;
using Splid.Domain.Ownership.Entities;

namespace Splid.Domain.Ownership.Interfaces
{
    public interface IPermissionsRepository : IRepository<Permission>
    {
        IEnumerable<Permission> GetByGroupId(Guid groupId);
    }
}
