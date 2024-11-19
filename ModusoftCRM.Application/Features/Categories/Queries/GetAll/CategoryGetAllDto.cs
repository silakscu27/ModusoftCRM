namespace ModusoftCRM.Application.Features.Categories.Queries.GetAll
{
    public class CategoryGetAllDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty; // non nullable error
        public string? Description { get; set; }
    }
}