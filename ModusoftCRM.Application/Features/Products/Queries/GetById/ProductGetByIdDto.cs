namespace ModusoftCRM.Application.Features.Products.Queries.GetById
{
    public class ProductGetByIdDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public int CategoryId { get; set; }
    }
}
