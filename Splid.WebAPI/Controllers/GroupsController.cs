using Microsoft.AspNetCore.Mvc;
using Splid.WebAPI.Core.Models.Groups;
using System;
using System.Threading.Tasks;

namespace Splid.WebAPI.Controllers
{
    //[EnableCors]
    public class GroupsController : Controller
    {
        //private readonly IGroupsAppService _groupAppSerivce;
        //private readonly IGroupsQueryService _groupsQueryService;

        public GroupsController()
        {

        }

        //public async Task<IActionResult> GetById(Guid groupId)
        //{
        //    try
        //    {
        //        var groupById = await _groupsQueryService.GetGroupByIdAsync(groupId);
        //        return Ok(groupById);
        //    }
        //    catch (ItemNotFoundException ex)
        //    {
        //        return NotFound(ex);
        //    }
        //}

        //public async Task<IActionResult> Create([FromBody]CreateGroupDto createGroupDto)
        //{
        //    await _groupAppSerivce.CreateGroupAsync(createGroupDto);
        //    return NoContent();
        //}

        //public async Task<IActionResult> Change(Guid groupId, [FromBody]ChangeGroupDto changeGroupData)
        //{
        //    await _groupAppSerivce.ChangeGroupAsync(groupId, changeGroupData);
        //    return NoContent();
        //}

        //public async Task<IActionResult> Delete(Guid groupId)
        //{
        //    await _groupAppSerivce.DeleteGroupAsync(groupId);
        //    return NoContent();
        //}
    }
}
