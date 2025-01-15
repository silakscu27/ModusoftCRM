using ModusoftCRM.Domain.Common;
using ModusoftCRM.Domain.Enums;

namespace ModusoftCRM.Domain.Entities
{
    public class Proposal : EntityBase<Guid>
    {
        public Guid FranchiseId { get; set; }
        public Franchise Franchise { get; set; } = null!;
        public string? ProjectId { get; set; }
        public Project? Project { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? No { get; set; }
        public ProposalStatus Status { get; set; }
        public CurrencyCode Currency { get; set; }
        public DateTimeOffset Date { get; set; }
        public DateTimeOffset ValidityDate { get; set; }
        // This description will be shown on the top side.
        public string? ShortDescription { get; set; }
        // This description will be shown on the bottom side.
        public string? Details { get; set; }
        public string? UserId { get; set; }
        public int TaxRate { get; set; }
        // Total Amount without any tax rate.
        public decimal TotalAmount { get; set; }

        // Total Amount + Tax Rate = FinalAmount
        public decimal FinalAmount { get; set; }


        public ICollection<ProposalItem> ProposalItems { get; set; } = new List<ProposalItem>();
    }
}