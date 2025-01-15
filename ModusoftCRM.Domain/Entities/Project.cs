using ModusoftCRM.Domain.Common;

namespace ModusoftCRM.Domain.Entities
{
    public class Project : EntityBase<string>
    {
        public string? Name { get; set; }
        public string? Description { get; set; }


        public ICollection<Proposal>? Proposals { get; set; }
        public ICollection<Order>? Orders { get; set; }
    }
}