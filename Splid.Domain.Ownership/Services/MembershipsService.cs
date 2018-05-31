using Splid.Domain.Ownership.Entities;
using Splid.Domain.Ownership.Enums;
using Splid.Domain.Ownership.Interfaces;
using System;
using System.Linq;

namespace Splid.Domain.Ownership.Services
{
    public class PermisionsService
    {
        private IPermissionsRepository _permissionsRepository;

        public bool CanChangeGroup(Guid groupId, Guid? ownerId)
        {
            var permissions = _permissionsRepository.GetByGroupId(groupId);
            
            if (!permissions.Any())
                return true;

            var permission = permissions.FirstOrDefault(p => p.OwnerId == ownerId);
            if (permission == null)
                return false;

            return permission.Type == PermissionType.Edit;
        }

        public bool CanDeleteGroup(Guid groupId, Guid? ownerId)
        {
            var permissions = _permissionsRepository.GetByGroupId(groupId);

            if (!permissions.Any())
                return false;

            var permission = permissions.FirstOrDefault(p => p.OwnerId == ownerId);
            if (permission == null)
                return false;

            return permission.Type == PermissionType.Delete;
        }

        public void CreatePermission(Guid groupId, Guid ownerId, PermissionType type)
        {
            var permission = new Permission(Guid.NewGuid(), groupId, ownerId, type);
            _permissionsRepository.Add(permission);
        }
    }
}
