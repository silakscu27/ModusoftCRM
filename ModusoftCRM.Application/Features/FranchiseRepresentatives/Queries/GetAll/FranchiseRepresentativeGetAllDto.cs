namespace ModusoftCRM.Application.Features.FranchiseRepresentatives.Queries.GetAll
{
    public class FranchiseRepresentativeGetAllDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string? FullName => $"{FirstName} {LastName}";
        public string? EmailAddress { get; set; }
        public string? PhoneNumber { get; set; }
        public string? MobilePhoneNumber { get; set; }
        public Guid FranchiseId { get; set; }
    }
}
