using MediatR;
using ModusoftCRM.Domain.Common;

namespace ModusoftCRM.Application.Features.Categories.Commands.Add
{
    public class CategoryAddCommand : IRequest<Response<int>>
    {
        public string Name { get; set; }
        public string? Description { get; set; }
    }
}