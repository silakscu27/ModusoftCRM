namespace ModusoftCRM.Application.Features.Customers.Queries.GetAll
{
    public class CustomerGetAllDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? ErpId { get; set; }
        public string? Picture { get; set; }
    }
}
