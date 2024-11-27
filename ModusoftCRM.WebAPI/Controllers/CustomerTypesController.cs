using CRM.Application.Features.CustomerTypes.Commands.Add;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ModusoftCRM.Application.Features.CustomerTypes.Queries.GetAll;
using ModusoftCRM.WebAPI.Abstractions;

namespace ModusoftCRM.WebApi.Controllers
{
    public sealed class CustomerTypesController : ApiController
    {
        public CustomerTypesController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(CustomerTypeAddCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return Ok(response); 
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync(CustomerTypeGetAllQuery request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return Ok(response); 
        }
    }
}
