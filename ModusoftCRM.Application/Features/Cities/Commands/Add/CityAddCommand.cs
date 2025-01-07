using MediatR;
using ModusoftCRM.Domain.Common;

namespace ModusoftCRM.Application.Features.Cities.Commands.Add
{
    public class CityAddCommand : IRequest<Response<int>>
    {
        public string Name { get; set; } = string.Empty;
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
        public int CountryId { get; set; }
    }
}
    