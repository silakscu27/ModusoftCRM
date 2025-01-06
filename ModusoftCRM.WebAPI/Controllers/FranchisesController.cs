using MediatR;
using Microsoft.AspNetCore.Mvc;
using ModusoftCRM.Application.Features.Franchises.Queries.GetAll;
using ModusoftCRM.Application.Features.Franchises.Queries.GetById;
using ModusoftCRM.WebAPI.Abstractions;
using ModusoftCRM.Application.Features.Franchises.Commands.Add;
using ModusoftCRM.Application.Features.Franchises.Commands.Update;

namespace ModusoftCRM.WebApi.Controllers
{
    public sealed class FranchisesController : ApiController
    {
        public FranchisesController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(FranchiseAddCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(FranchiseUpdateCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
        {
            var franchises = await _mediator.Send(new FranchiseGetAllQuery(), cancellationToken);
            return Ok(franchises);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var request = new FranchiseGetByIdQuery(id);
            var response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }
    }
}
