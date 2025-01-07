namespace ModusoftCRM.Application.Features.Countries.Queries.GetById
{
    public class CountryGetByIdDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
    }
}
