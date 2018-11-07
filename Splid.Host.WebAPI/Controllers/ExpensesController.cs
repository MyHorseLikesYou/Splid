using System;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Splid.Application.Commands.Groups.Expenses;
using Splid.Application.Queries;
using Splid.Domain.Main.Models;
using Splid.Host.WebAPI.Models.Expenses;

namespace Splid.Host.WebAPI.Controllers
{
    public class ExpensesController : Controller
    {
        private IMediator _mediator;
        private IMapper _mapper;

        public ExpensesController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<IActionResult> GetExpenseById(Guid groupId, Guid expenseId)
        {
            var getExpenseByIdQuery = new GetExpenseByIdQuery() {GroupId = groupId, ExpenseId = expenseId};
            var expense = await _mediator.Send(getExpenseByIdQuery);

            return Ok(expense);
        }

        public async Task<IActionResult> GetExpensesByGroupId(Guid groupId)
        {
            var getExpensesByGroupIdQuery = new GetExpensesByGroupIdQuery() {GroupId = groupId};
            var expenses = await _mediator.Send(getExpensesByGroupIdQuery);

            return Ok(expenses);
        }

        public async Task<IActionResult> CreateExpense(Guid groupId, [FromBody] CreateExpenseDto createExpenseDto)
        {
            var expenseId = Guid.NewGuid();
            var expenseInput = _mapper.Map<GroupExpenseInput>(createExpenseDto);
            var createExpenseCommand = new CreateExpenseCommand()
                {GroupId = groupId, ExpenseId = expenseId, Expense = expenseInput};
            await _mediator.Send(createExpenseCommand);

            var getExpenseByIdQuery = new GetExpenseByIdQuery() {GroupId = groupId, ExpenseId = expenseId};
            var expense = await _mediator.Send(getExpenseByIdQuery);

            return CreatedAtAction(nameof(GetExpenseById), new {groupId, expenseId}, expense);
        }

        public async Task<IActionResult> ChangeExpense(Guid groupId, Guid expenseId,
            [FromBody] ChangeExpenseDto changeExpenseDto)
        {
            var expenseInput = _mapper.Map<GroupExpenseInput>(changeExpenseDto);
            var changeExpenseCommand = new ChangeExpenseCommand()
                {GroupId = groupId, ExpenseId = expenseId, Expense = expenseInput};
            await _mediator.Send(changeExpenseCommand);

            return NoContent();
        }

        public async Task<IActionResult> DeleteExpense(Guid groupId, Guid expenseId)
        {
            var deleteExpenseCommand = new DeleteExpenseCommand() {GroupId = groupId, ExpenseId = expenseId};
            await _mediator.Send(deleteExpenseCommand);

            return NoContent();
        }
    }
}