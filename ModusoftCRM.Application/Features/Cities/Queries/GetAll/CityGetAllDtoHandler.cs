using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ModusoftCRM.Application.Common.Interfaces;

namespace ModusoftCRM.Application.Features.Cities.Queries.GetAll
{
    public class CityGetAllQueryHandler : IRequestHandler<CityGetAllQuery, List<CityGetAllDto>>
    {
        private readonly ITenantService _tenantService;
        private readonly IMapper _mapper;

        public CityGetAllQueryHandler(ITenantService tenantService, IMapper mapper)
        {
            _tenantService = tenantService;
            _mapper = mapper;
        }

        public async Task<List<CityGetAllDto>> Handle(CityGetAllQuery request, CancellationToken cancellationToken)
        {
            var dbContext = await _tenantService.GetDbInstance(cancellationToken);

            return await dbContext
                .Cities
                .Include(c => c.Country) 
                .AsNoTracking()
                .Select(city => new CityGetAllDto
                {
                    Id = city.Id,
                    Name = city.Name,
                    Latitude = city.Latitude,
                    Longitude = city.Longitude,
                    CountryName = city.Country.Name 
                })
                .ToListAsync(cancellationToken);
        }
    }
}
