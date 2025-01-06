using ModusoftCRM.Domain.Common;

namespace ModusoftCRM.Domain.Entities
{
    public class FranchiseRepresentative : EntityBase<Guid>
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

        public string FullName => $"{FirstName} {LastName}";

        public string? Description { get; set; }
        public string? PhoneNumber { get; set; }
        public string? MobilePhoneNumber { get; set; }
        public string? EmailAddress { get; set; }
        public string? LinkedIn { get; set; }

        public Guid FranchiseId { get; set; }
        public virtual Franchise? Franchise { get; set; }
        //public virtual ICollection<FranchiseRepresentativeHistory> FranchiseRepresentativeHistories { get; set; } = new List<FranchiseRepresentativeHistory>();
    }
}
