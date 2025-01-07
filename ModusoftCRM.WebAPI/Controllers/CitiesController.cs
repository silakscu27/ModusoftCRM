using MediatR;
using Microsoft.AspNetCore.Mvc;
using ModusoftCRM.Application.Features.Cities.Commands.Add;
using ModusoftCRM.Application.Features.Cities.Commands.Update;
using ModusoftCRM.Application.Features.Cities.Queries.GetAll;
using ModusoftCRM.Application.Features.Cities.Queries.GetById;
using ModusoftCRM.WebAPI.Abstractions;
using TS.Result;

namespace ModusoftCRM.WebApi.Controllers
{
    public sealed class CitiesController : ApiController
    {
        public CitiesController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(CityAddCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync(CityGetAllQuery request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            var request = new CityGetByIdQuery(id);
            var response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(CityUpdateCommand request, CancellationToken cancellationToken)
        {
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
