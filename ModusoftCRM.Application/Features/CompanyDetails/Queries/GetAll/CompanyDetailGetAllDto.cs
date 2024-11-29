namespace ModusoftCRM.Application.Features.CompanyDetails.Queries.GetAll
{
    public class CompanyDetailGetAllDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? LegalName { get; set; }
        public string? Logo { get; set; }
        public string? PhoneNumber { get; set; }
        public string? LegalAddress { get; set; }
        public string? Email { get; set; }
        public bool IsDefault { get; set; }
    }
}
