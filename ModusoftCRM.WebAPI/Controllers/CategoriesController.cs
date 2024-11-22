using Azure.Core;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ModusoftCRM.Application.Features.Categories.Commands.Add;
using ModusoftCRM.Application.Features.Categories.Queries.GetAll;
using ModusoftCRM.Application.Features.Categories.Queries.GetById;
using ModusoftCRM.WebAPI.Abstractions;
using TS.Result;

namespace ModusoftCRM.WebApi.Controllers
{
    public sealed class CategoriesController : ApiController
    {
        public CategoriesController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(CategoryAddCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync(CategoryGetAllQuery request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return Ok(response);

        }

        [HttpGet]
        public async Task<IActionResult> GetByIdAsync(CategoryGetByIdQuery request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return Ok(response);

        }
    }
}