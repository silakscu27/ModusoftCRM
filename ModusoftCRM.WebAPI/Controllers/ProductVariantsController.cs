using MediatR;
using Microsoft.AspNetCore.Mvc;
using ModusoftCRM.Application.Features.ProductVariants.Commands.Add;
using ModusoftCRM.Application.Features.ProductVariants.Commands.Update;
using ModusoftCRM.Application.Features.ProductVariants.Queries.GetAll;
using ModusoftCRM.Application.Features.ProductVariants.Queries.GetById;
using ModusoftCRM.WebAPI.Abstractions;

namespace ModusoftCRM.WebApi.Controllers
{
    public sealed class ProductVariantsController : ApiController
    {
        public ProductVariantsController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(ProductVariantAddCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync(ProductVariantGetAllQuery request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            var request = new ProductVariantGetByIdQuery(id);
            var response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(ProductVariantUpdateCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }
    }
}
