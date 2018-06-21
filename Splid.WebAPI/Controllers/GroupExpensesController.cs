using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Splid.Application.Queries;
using Splid.WebAPI.Core.Models.Groups;

namespace Splid.WebAPI.Controllers
{   
    public class GroupExpensesController : Controller
    {
        private IMediator _mediator;
        private IMapper _mapper;

        public async Task<IActionResult> GetById(Guid groupExpenseId)
        {
            var getGroupExpenseByIdQuery = _mapper.Map<GetGroupExpenseByIdQuery>(groupExpenseId);
            var groupExpense = await _mediator.Send(getGroupExpenseByIdQuery);

            return Ok(groupExpense);
        }
       
        public GetExpenseByIdDto Change(long expenseId, [FromBody]ChangeExpenseDto value)
        {
            return new GetExpenseByIdDto();
        }
        
        public void Delete(long expenseId)
        {
        }
    }
}
