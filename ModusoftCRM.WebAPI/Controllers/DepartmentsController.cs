using MediatR;
using Microsoft.AspNetCore.Mvc;
using ModusoftCRM.Application.Features.Departments.Commands.Add;
using ModusoftCRM.Application.Features.Departments.Commands.Update;
using ModusoftCRM.Application.Features.Departments.Queries.GetAll;

namespace ModusoftCRM.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartmentsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DepartmentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(DepartmentAddCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(DepartmentUpdateCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new DepartmentGetAllQuery(), cancellationToken);
            return Ok(response);
        }

    }
}
