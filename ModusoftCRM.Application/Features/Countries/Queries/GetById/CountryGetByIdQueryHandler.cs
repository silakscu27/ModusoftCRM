using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ModusoftCRM.Application.Common.Interfaces;

namespace ModusoftCRM.Application.Features.Countries.Queries.GetById
{
    public class CountryGetByIdQueryHandler : IRequestHandler<CountryGetByIdQuery, CountryGetByIdDto>
    {
        private readonly ITenantService _tenantService;
        private readonly IMapper _mapper;

        public CountryGetByIdQueryHandler(ITenantService tenantService, IMapper mapper)
        {
            _tenantService = tenantService;
            _mapper = mapper;
        }

        public async Task<CountryGetByIdDto> Handle(CountryGetByIdQuery request, CancellationToken cancellationToken)
        {
            var dbContext = await _tenantService.GetDbInstance(cancellationToken);

            var country = await dbContext.Countries
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (country == null)
            {
                throw new Exception("Ülke bulunamadı.");
            }

            return _mapper.Map<CountryGetByIdDto>(country);
        }
    }
}
