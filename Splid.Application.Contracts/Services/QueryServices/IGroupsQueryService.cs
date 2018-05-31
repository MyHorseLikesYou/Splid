using Splid.WebAPI.Core.Models.Groups;
using System;
using System.Threading.Tasks;

namespace Splid.Application.Contracts.Services.QueryServices
{
    public interface IGroupsQueryService
    {
        GetGroupByIdDto GetGroupById(Guid groupId);
        Task<GetGroupByIdDto> GetGroupByIdAsync(Guid groupId);
    }
}
