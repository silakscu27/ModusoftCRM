using ModusoftCRM.Domain.Common;
using ModusoftCRM.Domain.Enums;

namespace ModusoftCRM.Domain.Entities
{
    public class Order : EntityBase<Guid>
    {
        public Guid FranchiseId { get; set; }
        public Franchise Franchise { get; set; } = null!; 
        //public string? ProjectId { get; set; }
        //public Project? Project { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? No { get; set; }
        public OrderStatus Status { get; set; }
        public CurrencyCode Currency { get; set; }
        public DateTimeOffset Date { get; set; }
        public DateTimeOffset ValidityDate { get; set; }
        public string? ShortDescription { get; set; }
        public string? Details { get; set; }
        public string? UserId { get; set; }
        public int TaxRate { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal FinalAmount { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>(); // Varsayılan değer atandı.
    }
}
