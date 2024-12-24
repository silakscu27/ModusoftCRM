using ModusoftCRM.Domain.Common;

namespace ModusoftCRM.Domain.Entities
{
    public class FranchiseType : EntityBase<Guid>
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public bool IsDefault { get; set; }
        public virtual ICollection<Franchise>? Franchises { get; set; }
    }
}
