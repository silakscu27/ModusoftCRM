using MediatR;
using ModusoftCRM.Domain.Common;

namespace ModusoftCRM.Application.Features.FranchiseRepHistories.Commands.Add
{
    public class FranchiseRepHistoryAddCommand : IRequest<Response<int>>
    {
        public Guid FranchiseRepresentativeId { get; set; }
        public Guid FranchiseId { get; set; }
        public DateTimeOffset From { get; set; }
        public DateTimeOffset To { get; set; }
        public string Role { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}
