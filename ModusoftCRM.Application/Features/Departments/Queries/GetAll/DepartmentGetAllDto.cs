namespace ModusoftCRM.Application.Features.Departments.Queries.GetAll
{
    public class DepartmentGetAllDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}
