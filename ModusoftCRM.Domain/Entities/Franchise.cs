using ModusoftCRM.Domain.Common;
using ModusoftCRM.Domain.Enums;

namespace ModusoftCRM.Domain.Entities
{
    public class Franchise : EntityBase<Guid>
    {
        public Franchise(Guid id, string createdByUserId)
        {
            Id = id;
            CreatedByUserId = createdByUserId;
        }

        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
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
        public Guid CustomerId { get; set; }
        public Customer? Customer { get; set; } 
        public int? CountryId { get; set; }
        public int? CityId { get; set; }
        public Guid FranchiseTypeId { get; set; }
        public FranchiseType? FranchiseType { get; set; } 
    }
}
