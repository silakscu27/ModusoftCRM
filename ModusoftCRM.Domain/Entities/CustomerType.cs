using ModusoftCRM.Domain.Common;

namespace ModusoftCRM.Domain.Entities
{
    public class CustomerType : EntityBase<int>
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}
