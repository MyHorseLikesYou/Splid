using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Splid.WebAPI.Core.Models.Groups;

namespace Splid.WebAPI.Controllers
{   
    public class ExpensesController : Controller
    {
        public GetExpenseByIdDto GetById(long expenseId)
        {
            return new GetExpenseByIdDto();
        }

        public IEnumerable<GetExpensesByGroupIdItemDto> GetByGroupId(long groupId)
        {
            return new GetExpensesByGroupIdItemDto[] {};
        }
        
        public GetExpenseByIdDto Create(long groupId, [FromBody]CreateExpenseDto value)
        {
            return new GetExpenseByIdDto();
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
