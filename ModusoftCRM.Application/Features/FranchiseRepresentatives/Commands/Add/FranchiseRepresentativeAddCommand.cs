using MediatR;
using ModusoftCRM.Domain.Common;

namespace ModusoftCRM.Application.Features.FranchiseRepresentatives.Commands.Add
{
    public class FranchiseRepresentativeAddCommand : IRequest<Response<Guid>>
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? PhoneNumber { get; set; }
        public string? MobilePhoneNumber { get; set; }
        public string? EmailAddress { get; set; }
        public string? LinkedIn { get; set; }
        public Guid FranchiseId { get; set; }
    }
}
