using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Splid.Application.Commands.Expenses;
using Splid.Application.Commands.Groups;
using Splid.Application.Queries;
using Splid.WebAPI.Core.Models.Groups;
using System;
using System.Threading.Tasks;

namespace Splid.WebAPI.Controllers
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

        public async Task<IActionResult> GetById(Guid groupId)
        {
            var getGroupByIdQuery = _mapper.Map<GetGroupByIdQuery>(groupId);
            var group = await _mediator.Send(getGroupByIdQuery);

            return Ok(group);
        }

        public async Task<IActionResult> Create([FromBody]CreateGroupDto createGroupDto)
        {
            var createGroupCommand = _mapper.Map<CreateGroupCommand>(createGroupDto);
            await _mediator.Send(createGroupCommand);

            var getGroupByIdQuery = _mapper.Map<GetGroupByIdQuery>(createGroupCommand.GroupId);
            var group = await _mediator.Send(getGroupByIdQuery);

            return CreatedAtAction(nameof(GetById), group.Id, group);
        }

        public async Task<IActionResult> Change(Guid groupId, [FromBody]ChangeGroupDto changeGroupData)
        {
            var changeGroupCommand = _mapper.Map<ChangeGroupCommand>(changeGroupData);
            await _mediator.Send(changeGroupCommand);

            return NoContent();
        }

        public async Task<IActionResult> Delete(Guid groupId)
        {
            var deleteGroupCommand = _mapper.Map<DeleteGroupCommand>(groupId);
            await _mediator.Send(deleteGroupCommand);

            return NoContent();
        }

        public async Task<IActionResult> GetGroupExpensesByGroupId(Guid groupId)
        {
            var getGroupExpensesByGroupIdQuery = _mapper.Map<GetGroupExpensesByGroupIdQuery>(groupId);
            var groupExpenses = await _mediator.Send(getGroupExpensesByGroupIdQuery);

            return Ok(groupExpenses);
        }

        public async Task<IActionResult> CreateGroupExpense(Guid groupId, [FromBody]CreateExpenseDto value)
        {
            var createGroupExpenseCommand = _mapper.Map<CreateGroupExpenseCommand>(value);
            createGroupExpenseCommand.GroupId = groupId;
            await _mediator.Send(createGroupExpenseCommand);

            var getGroupByIdQuery = _mapper.Map<GetGroupExpenseByIdQuery>(createGroupExpenseCommand.ExpenseId);
            var group = await _mediator.Send(getGroupByIdQuery);

            return CreatedAtAction(nameof(GroupExpensesController.GetById), nameof(GroupExpensesController), createGroupExpenseCommand.ExpenseId);
        }
    }
}
