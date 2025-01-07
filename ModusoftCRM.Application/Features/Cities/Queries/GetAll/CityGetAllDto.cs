namespace ModusoftCRM.Application.Features.Cities.Queries.GetAll
{
    public class CityGetAllDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
        public string? CountryName { get; set; }
    }
}
