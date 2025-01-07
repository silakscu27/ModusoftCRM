using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ModusoftCRM.Application.Common.Interfaces;

namespace ModusoftCRM.Application.Features.Countries.Queries.GetAll
{
    public class CountryGetAllQueryHandler : IRequestHandler<CountryGetAllQuery, List<CountryGetAllDto>>
    {
        private readonly ITenantService _tenantService;
        private readonly IMapper _mapper;

        public CountryGetAllQueryHandler(ITenantService tenantService, IMapper mapper)
        {
            _tenantService = tenantService;
            _mapper = mapper;
        }

        public async Task<List<CountryGetAllDto>> Handle(CountryGetAllQuery request, CancellationToken cancellationToken)
        {
            var dbContext = await _tenantService.GetDbInstance(cancellationToken);

            return await dbContext
                .Countries
                .AsNoTracking()  
                .Select(x => _mapper.Map<CountryGetAllDto>(x))  
                .ToListAsync(cancellationToken);
        }
    }
}
