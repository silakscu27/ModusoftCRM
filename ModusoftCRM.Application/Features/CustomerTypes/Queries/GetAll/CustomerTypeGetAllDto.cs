namespace ModusoftCRM.Application.Features.CustomerTypes.Queries.GetAll
{
    public class CustomerTypeGetAllDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}
