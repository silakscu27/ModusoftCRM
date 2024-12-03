using MediatR;
using Microsoft.AspNetCore.Mvc;
using ModusoftCRM.Application.Features.Employees.Commands.Add;
using ModusoftCRM.Application.Features.Employees.Commands.Update;
using ModusoftCRM.Application.Features.Employees.Queries.GetAll;
using ModusoftCRM.Application.Features.Employees.Queries.GetById;
using ModusoftCRM.WebAPI.Abstractions;

namespace ModusoftCRM.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public sealed class EmployeesController : ApiController
    {
        public EmployeesController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(EmployeeAddCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(EmployeeUpdateCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
        {
            var employees = await _mediator.Send(new EmployeeGetAllQuery(), cancellationToken);
            return Ok(employees);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var request = new EmployeeGetByIdQuery(id);
            var response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(id, cancellationToken);
            return Ok(response);
        }
    }
}
