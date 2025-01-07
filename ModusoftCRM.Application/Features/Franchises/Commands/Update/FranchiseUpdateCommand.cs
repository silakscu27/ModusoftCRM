using MediatR;
using ModusoftCRM.Domain.Common;
using ModusoftCRM.Domain.Enums;

namespace ModusoftCRM.Application.Features.Franchises.Commands.Update
{
    public class FranchiseUpdateCommand : IRequest<Response<Guid>>
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Address { get; set; }
        public string? PostalCode { get; set; }
        public string? PhoneNumber { get; set; }
        public string? FaxNumber { get; set; }
        public string? TaxId { get; set; }
        public string? TaxAdministration { get; set; }
        public string? LegalTaxName { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
        public string? Picture { get; set; }
        public string? Website { get; set; }
        public string? LinkedIn { get; set; }
        public FranchiseTrustLevel TrustLevel { get; set; }
        public int FranchiseTypeId { get; set; }
        public int CustomerId { get; set; }
    }
}
