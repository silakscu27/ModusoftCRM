namespace ModusoftCRM.Application.Features.Categories.Queries.GetById
{
    public class CategoryGetByIdDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}