namespace ModusoftCRM.Application.Features.FranchiseRepHistories.Queries.GetAll
{
    public class FranchiseRepHistoryGetAllDto
    {
        public int Id { get; set; }
        public Guid FranchiseRepresentativeId { get; set; }
        public Guid FranchiseId { get; set; }
        public DateTimeOffset From { get; set; }
        public DateTimeOffset To { get; set; }
        public string Role { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}
