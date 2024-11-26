using ModusoftCRM.Domain.Common;

namespace ModusoftCRM.Domain.Entities
{
    public class Customer : EntityBase<int>
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? ErpId { get; set; }
        public string? Picture { get; set; }
        
        // public ICollection<Franchise> Franchises { get; set; }

    }
}