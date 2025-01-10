using MediatR;
using Microsoft.AspNetCore.Mvc;
using ModusoftCRM.Application.Features.ProductVariantUnitPrices.Commands;
using ModusoftCRM.Application.Features.ProductVariantUnitPrices.Commands.Add;
using ModusoftCRM.Application.Features.ProductVariantUnitPrices.Commands.Update;
using ModusoftCRM.Application.Features.ProductVariantUnitPrices.Queries.GetAll;
using ModusoftCRM.Application.Features.ProductVariantUnitPrices.Queries.GetById;
using ModusoftCRM.WebAPI.Abstractions;

namespace ModusoftCRM.WebApi.Controllers
{
    public sealed class ProductVariantUnitPricesController : ApiController
    {
        public ProductVariantUnitPricesController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(ProductVariantUnitPriceAddCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(ProductVariantUnitPriceUpdateCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
        {
            var productVariantUnitPrices = await _mediator.Send(new ProductVariantUnitPriceGetAllQuery(), cancellationToken);
            return Ok(productVariantUnitPrices);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            var request = new ProductVariantUnitPriceGetByIdQuery(id);
            var response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }

        
    }
}
