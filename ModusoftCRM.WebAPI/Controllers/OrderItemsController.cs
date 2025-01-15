using MediatR;
using Microsoft.AspNetCore.Mvc;
using ModusoftCRM.Application.Features.OrderItems.Commands;
using ModusoftCRM.Application.Features.OrderItems.Commands.Add;
using ModusoftCRM.Application.Features.OrderItems.Commands.Update;
using ModusoftCRM.Application.Features.OrderItems.Queries;
using ModusoftCRM.Application.Features.OrderItems.Queries.GetAll;
using ModusoftCRM.Application.Features.OrderItems.Queries.GetById;
using ModusoftCRM.WebAPI.Abstractions;

namespace ModusoftCRM.WebApi.Controllers
{
    public sealed class OrderItemsController : ApiController
    {
        public OrderItemsController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(OrderItemAddCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(OrderItemUpdateCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
        {
            var orderItems = await _mediator.Send(new OrderItemGetAllQuery(), cancellationToken);
            return Ok(orderItems);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            var request = new OrderItemGetByIdQuery(id);
            var response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteByIdAsync(int id, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(id, cancellationToken);
            return Ok(response);
        }
    }
}
