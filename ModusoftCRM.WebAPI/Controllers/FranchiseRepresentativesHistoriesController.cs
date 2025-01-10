using MediatR;
using Microsoft.AspNetCore.Mvc;
using ModusoftCRM.Application.Features.FranchiseRepHistories.Commands.Add;
using ModusoftCRM.Application.Features.FranchiseRepHistories.Commands.Update;
using ModusoftCRM.Application.Features.FranchiseRepHistories.Queries.GetAll;
using ModusoftCRM.Application.Features.FranchiseRepHistories.Queries.GetById;
using ModusoftCRM.WebAPI.Abstractions;

namespace ModusoftCRM.WebApi.Controllers
{
    public sealed class FranchiseRepresentativesHistoriesController : ApiController
    {
        public FranchiseRepresentativesHistoriesController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(FranchiseRepHistoryAddCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(FranchiseRepHistoryUpdateCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
        {
            var franchiseRepHistories = await _mediator.Send(new FranchiseRepHistoryGetAllQuery(), cancellationToken);
            return Ok(franchiseRepHistories);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            var request = new FranchiseRepHistoryGetByIdQuery(id);
            var response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }
    }
}
