using ModusoftCRM.Domain.Common;

namespace ModusoftCRM.Domain.Entities
{
    public class Country : EntityBase<int>
    {
        public string Name { get; set; } = string.Empty;
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }

        public ICollection<City>? Cities { get; set; } 
        public ICollection<Franchise>? Franchises { get; set; } 
    }
}
