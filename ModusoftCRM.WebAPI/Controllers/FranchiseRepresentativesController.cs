using MediatR;
using Microsoft.AspNetCore.Mvc;
using ModusoftCRM.Application.Features.FranchiseRepresentatives.Commands.Add;
using ModusoftCRM.Application.Features.FranchiseRepresentatives.Queries.GetAll;
using ModusoftCRM.WebAPI.Abstractions;

namespace ModusoftCRM.WebApi.Controllers
{
    public sealed class FranchiseRepresentativesController : ApiController
    {
        public FranchiseRepresentativesController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(FranchiseRepresentativeAddCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
        {
            var representatives = await _mediator.Send(new FranchiseRepresentativeGetAllQuery(), cancellationToken);
            return Ok(representatives);
        }
    }
}
