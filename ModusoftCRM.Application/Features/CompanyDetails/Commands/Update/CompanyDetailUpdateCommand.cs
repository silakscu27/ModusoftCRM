using MediatR;
using ModusoftCRM.Domain.Common;

namespace CRM.Application.Features.CompanyDetails.Commands.Update
{
    public class CompanyDetailUpdateCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? LegalName { get; set; }
        public string? Logo { get; set; }
        public string? WorkPhoneNumber { get; set; }
        public string? LegalAddress { get; set; }
        public string? Email { get; set; }
        public bool IsDefault { get; set; }
    }
}