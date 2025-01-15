namespace ModusoftCRM.Application.Features.Projects.Queries.GetById
{
    public class ProjectGetByIdDto
    {
        public string Id { get; set; } = string.Empty;
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}
