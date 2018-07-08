using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Splid.Application.Commands.Payments;
using Splid.Application.Queries;
using Splid.Domain.Models.Groups;
using Splid.WebAPI.Models.Payments;
using System;
using System.Threading.Tasks;

namespace Splid.WebAPI.Controllers
{
    public class PaymentsController : Controller
    {
        private IMediator _mediator;
        private IMapper _mapper;

        public PaymentsController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<IActionResult> GetPaymentById(Guid groupId, Guid paymentId)
        {
            var getPaymentByIdQuery = new GetPaymentByIdQuery() { GroupId = groupId, PaymentId = paymentId };
            var payment = await _mediator.Send(getPaymentByIdQuery);

            return Ok(payment);
        }

        public async Task<IActionResult> GetPaymentsByGroupId(Guid groupId)
        {
            var getPaymentsByGroupIdQuery = new GetPaymentsByGroupIdQuery { GroupId = groupId };
            var payments = await _mediator.Send(getPaymentsByGroupIdQuery);

            return Ok(payments);
        }

        public async Task<IActionResult> CreatePayment(Guid groupId, [FromBody]CreatePaymentDto createPaymentDto)
        {
            var paymentId = Guid.NewGuid();
            var paymentInput = _mapper.Map<PaymentInput>(createPaymentDto);
            var createPaymentCommand = new CreatePaymentCommand() { GroupId = groupId, PaymentId = paymentId, Payment = paymentInput };
            await _mediator.Send(createPaymentCommand);

            var getPaymentByIdQuery = _mapper.Map<GetPaymentByIdQuery>(paymentId);
            var payment = await _mediator.Send(getPaymentByIdQuery);

            return CreatedAtAction(nameof(GetPaymentById), new { groupId, payment }, payment);
        }

        public async Task<IActionResult> Change(Guid groupId, Guid paymentId, [FromBody]ChangePaymentDto changePaymentDto)
        {
            var paymentInput = _mapper.Map<PaymentInput>(changePaymentDto);
            var changePaymentCommand = new ChangePaymentCommand() { GroupId = groupId, PaymentId = paymentId, Payment = paymentInput);
            await _mediator.Send(changePaymentCommand);

            return NoContent();
        }

        public async Task<IActionResult> Delete(Guid groupId, Guid paymentId)
        {
            var deletePaymentCommand = new DeletePaymentCommand() { GroupId = groupId, PaymentId = paymentId };
            await _mediator.Send(deletePaymentCommand);

            return NoContent();
        }
    }
}
