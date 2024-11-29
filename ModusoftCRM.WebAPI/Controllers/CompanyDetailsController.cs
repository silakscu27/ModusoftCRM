using MediatR;
using Microsoft.AspNetCore.Mvc;
using CRM.Application.Features.CompanyDetails.Commands.Add;
using CRM.Application.Features.CompanyDetails.Commands.Update;
using ModusoftCRM.WebAPI.Abstractions;
using ModusoftCRM.Application.Features.CompanyDetails.Queries.GetAll;
using ModusoftCRM.Application.Features.CompanyDetails.Queries.GetById;

namespace CRM.WebApi.Controllers
{
    public sealed class CompanyDetailsController : ApiController
    {
        public CompanyDetailsController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(CompanyDetailAddCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(CompanyDetailUpdateCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync(CompanyDetailGetAllQuery request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAsync(int id, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(id, cancellationToken);
            return Ok(response);
        }

        // Yeni GetById metodu eklendi
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            var request = new CompanyDetailGetByIdQuery(id);
            var response = await _mediator.Send(request, cancellationToken);

            // Eğer şirket detayı bulunamazsa, 404 dönebiliriz
            if (!response.Succeeded)
            {
                return NotFound(response.Message);
            }

            return Ok(response);
        }
    }
}
