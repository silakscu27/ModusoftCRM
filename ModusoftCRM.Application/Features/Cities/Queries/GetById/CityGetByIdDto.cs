namespace ModusoftCRM.Application.Features.Cities.Queries.GetById
{
    public class CityGetByIdDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
        public string? CountryName { get; set; }
    }
}
