using System;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Splid.Application.Commands.Groups;
using Splid.Application.Queries;
using Splid.Domain.Main.Models.Groups;
using Splid.Host.WebAPI.Models.Groups;

namespace Splid.Host.WebAPI.Controllers
{
    public class GroupsController : Controller
    {
        private IMediator _mediator;
        private IMapper _mapper;

        public GroupsController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<IActionResult> GetGroupById(Guid groupId)
        {
            var getGroupByIdQuery = new GetGroupByIdQuery() { GroupId = groupId };
            var group = await _mediator.Send(getGroupByIdQuery);

            return Ok(group);
        }

        public async Task<IActionResult> CreateGroup([FromBody]CreateGroupDto createGroupDto)
        {
            var groupId = Guid.NewGuid();
            var groupInput = _mapper.Map<GroupInput>(createGroupDto);
            var createGroupCommand = new CreateGroupCommand() { GroupId = groupId, Group = groupInput };
            await _mediator.Send(createGroupCommand);

            var getGroupByIdQuery = new GetGroupByIdQuery() { GroupId = groupId };
            var group = await _mediator.Send(getGroupByIdQuery);

            return CreatedAtAction(nameof(GetGroupById), new { groupId }, group);
        }

        public async Task<IActionResult> ChangeGroup(Guid groupId, [FromBody]ChangeGroupDto changeGroupDto)
        {
            var groupInput = _mapper.Map<GroupInput>(changeGroupDto);
            var changeGroupCommand = new ChangeGroupCommand() { GroupId = groupId, Group = groupInput };
            await _mediator.Send(changeGroupCommand);

            return NoContent();
        }

        public async Task<IActionResult> DeleteGroup(Guid groupId)
        {
            var deleteGroupCommand = new DeleteGroupCommand() { GroupId = groupId };
            await _mediator.Send(deleteGroupCommand);

            return NoContent();
        }
    }
}
