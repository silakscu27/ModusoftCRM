using ModusoftCRM.Domain.Common;

namespace ModusoftCRM.Domain.Entities
{
    public class FranchiseRepresentativeHistory : EntityBase<int>
    {
        public Guid FranchiseRepresentativeId { get; set; }

        public Guid FranchiseId { get; set; }

        public DateTimeOffset From { get; set; }
        public DateTimeOffset To { get; set; }

        public string Role { get; set; } = string.Empty;
        public string? Description { get; set; }

        public Franchise Franchise { get; set; } = null!;

        public FranchiseRepresentative FranchiseRepresentative { get; set; } = null!;

    }
}
