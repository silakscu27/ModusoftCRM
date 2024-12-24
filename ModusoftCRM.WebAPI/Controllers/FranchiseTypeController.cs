using MediatR;
using Microsoft.AspNetCore.Mvc;
using ModusoftCRM.Application.Features.FranchiseTypes.Queries.GetAll;
using ModusoftCRM.WebAPI.Abstractions;

namespace ModusoftCRM.WebAPI.Controllers
{
    public sealed class FranchiseTypesController : ApiController
    {
        public FranchiseTypesController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
        {
            var franchiseTypes = await _mediator.Send(new FranchiseTypeGetAllQuery(), cancellationToken);
            return Ok(franchiseTypes);
        }
    }
}
