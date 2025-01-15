using ModusoftCRM.Domain.Common;

namespace ModusoftCRM.Domain.Entities
{
    public class Product : EntityBase<int>
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }

        public int? CategoryId { get; set; }
        public Category? Category { get; set; }
        public virtual ICollection<ProductVariant>? ProductVariant { get; set; }
    }
}
