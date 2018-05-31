using MyApp.Core.Domain;
using Splid.Domain.Ownership.Enums;
using System;

namespace Splid.Domain.Ownership.Entities
{
    public class Permission : Entity
    {
        public Permission(Guid id, Guid ownerId, Guid groupId, PermissionType type) 
            : base(id)
        {
        }

        public Guid OwnerId { get; set; }
        public Guid GroupId { get; set; }
        public PermissionType Type { get; set; }
    }
}
