﻿namespace ModusoftCRM.Application.Features.Franchises.Queries.GetAll
{
    public class FranchiseGetAllDto
    {
        public Guid Id { get; set; }
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
        public string TrustLevel { get; set; } = string.Empty; 
        public Guid CustomerId { get; set; }
        public string? CustomerName { get; set; } 
        public int? CountryId { get; set; }
        public int? CityId { get; set; }
        public Guid FranchiseTypeId { get; set; }
        public string? FranchiseTypeName { get; set; } 
    }
}
