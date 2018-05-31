using Splid.WebAPI.Core.Models.Groups;
using System;
using System.Threading.Tasks;

namespace Splid.Application.Contracts.Services
{
    public interface IGroupsAppService
    {
        void CreateGroup(CreateGroupDto createGroupData);
        Task CreateGroupAsync(CreateGroupDto createGroupData);

        void ChangeGroup(Guid groupId, ChangeGroupDto changedGroupData);
        Task ChangeGroupAsync(Guid groupId, ChangeGroupDto changedGroupData);

        void DeleteGroup(Guid groupId);
        Task DeleteGroupAsync(Guid groupId);
    }
}
