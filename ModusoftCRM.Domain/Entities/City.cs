using ModusoftCRM.Domain.Common;

namespace ModusoftCRM.Domain.Entities
{
    public class City : EntityBase<int>
    {
        public string Name { get; set; } = string.Empty;
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }

        // Relationship
        public int CountryId { get; set; }
        public Country Country { get; set; } = null!;
    }
}
