namespace ModusoftCRM.Application.Features.Customers.Queries.GetById
{
    public class CustomerGetByIdDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? ErpId { get; set; }
        public string? Picture { get; set; }
    }
}
