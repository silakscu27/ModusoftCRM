using CRM.Application.Customers.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ModusoftCRM.Application.Features.Customers.Queries.GetAll;
using ModusoftCRM.WebAPI.Abstractions;

namespace ModusoftCRM.WebApi.Controllers
{
    public sealed class CustomersController : ApiController
    {
        public CustomersController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(CustomerAddCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(CustomerUpdateCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
        {
            var customers = await _mediator.Send(new CustomerGetAllQuery(), cancellationToken);
            return Ok(customers); 
        }

    }
}
