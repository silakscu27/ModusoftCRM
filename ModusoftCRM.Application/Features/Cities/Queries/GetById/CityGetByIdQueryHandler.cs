using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ModusoftCRM.Application.Common.Interfaces;
using ModusoftCRM.Domain.Common;

namespace ModusoftCRM.Application.Features.Cities.Queries.GetById
{
    public class CityGetByIdQueryHandler : IRequestHandler<CityGetByIdQuery, Response<CityGetByIdDto>>
    {
        private readonly ITenantService _tenantService;
        private readonly IMapper _mapper;

        public CityGetByIdQueryHandler(ITenantService tenantService, IMapper mapper)
        {
            _tenantService = tenantService;
            _mapper = mapper;
        }

        public async Task<Response<CityGetByIdDto>> Handle(CityGetByIdQuery request, CancellationToken cancellationToken)
        {
            var dbContext = await _tenantService.GetDbInstance(cancellationToken);

            var city = await dbContext.Cities
                .Include(c => c.Country) 
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (city == null)
            {
                return new Response<CityGetByIdDto>("City not found");
            }

            var cityDto = _mapper.Map<CityGetByIdDto>(city);
            return new Response<CityGetByIdDto>(cityDto);
        }
    }
}
