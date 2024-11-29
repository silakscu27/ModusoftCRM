using ModusoftCRM.Domain.Common;

namespace ModusoftCRM.Domain.Entities
{
    public class CompanyDetail : EntityBase<int> 
    {
        public string Name { get; set; } = string.Empty;
        public string? LegalName { get; set; }
        public string? Logo { get; set; }
        public string? PhoneNumber { get; set; }
        public string? LegalAddress { get; set; }
        public string? Email { get; set; }
        public bool IsDefault { get; set; }

    }
}
