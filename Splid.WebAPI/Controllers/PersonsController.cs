using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Splid.Application.Commands.Groups.Persons;
using Splid.Application.Queries;
using Splid.Domain.Main.Models.Groups;
using Splid.WebAPI.Models.Persons;
using System;
using System.Threading.Tasks;

namespace Splid.WebAPI.Controllers
{
    public class PersonsController : Controller
    {
        private IMediator _mediator;
        private IMapper _mapper;

        public async Task<IActionResult> GetPersonById(Guid groupId, Guid personId)
        {
            var getPersonByIdQuery = new GetPersonByIdQuery() { GroupId = groupId, PersonId = personId };
            var person = await _mediator.Send(getPersonByIdQuery);

            return Ok(person);
        }

        public async Task<IActionResult> GetPersonsByGroupId(Guid groupId)
        {
            var getPersonsByGroupIdQuery = new GetPersonsByGroupIdQuery() { GroupId = groupId };
            var persons = await _mediator.Send(getPersonsByGroupIdQuery);

            return Ok(persons);
        }

        public async Task<IActionResult> CreatePerson(Guid groupId, [FromBody]CreatePersonDto createPersonDto)
        {
            var personId = Guid.NewGuid();
            var personInput = _mapper.Map<PersonInput>(createPersonDto);
            var createPersonCommand = new CreatePersonCommand() { GroupId = groupId, PersonId = personId, Person = personInput };
            await _mediator.Send(createPersonCommand);

            var getPersonByIdQuery = new GetPersonByIdQuery() { PersonId = personId };
            var person = await _mediator.Send(getPersonByIdQuery);

            return CreatedAtAction(nameof(GetPersonById), new { groupId, personId }, person);
        }

        public async Task<IActionResult> ChangePerson(Guid groupId, Guid personId, [FromBody]ChangePersonDto changePersonDto)
        {
            var personInput = _mapper.Map<PersonInput>(changePersonDto);
            var changePersonCommand = new ChangePersonCommand() { GroupId = groupId, PersonId = personId, Person = personInput };
            await _mediator.Send(changePersonCommand);

            return NoContent();
        }

        public async Task<IActionResult> DeleteExpense(Guid groupId, Guid personId)
        {
            var deletePersonCommand = new DeletePersonCommand() { GroupId = groupId, PersonId = personId };
            await _mediator.Send(deletePersonCommand);

            return NoContent();
        }
    }
}
