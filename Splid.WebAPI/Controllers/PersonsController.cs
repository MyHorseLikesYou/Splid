using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Splid.WebAPI.Core.Models.Persons;

namespace Splid.WebAPI.Controllers
{   
    public class PersonsController : Controller
    {
        public IEnumerable<GetPersonsByGroupIdItemDto> GetByGroupId(long groupId)
        {
            return new GetPersonsByGroupIdItemDto[] {};
        }
        
        public GetPersonByIdDto Create(long groupId, [FromBody]CreatePersonDto value)
        {
            return new GetPersonByIdDto();
        }
        
        public GetPersonByIdDto Change(long personId, [FromBody]ChangePersonDto value)
        {
            return new GetPersonByIdDto();
        }
        
        public void Delete(long personId)
        {
        }
    }
}
