using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ModusoftCRM.Application.Common.Interfaces;

namespace ModusoftCRM.Application.Features.CompanyDetails.Queries.GetAll
{
    public class CompanyDetailGetAllQueryHandler : IRequestHandler<CompanyDetailGetAllQuery, List<CompanyDetailGetAllDto>>
    {
        private readonly ITenantService _tenantService;
        private readonly IMapper _mapper;

        public CompanyDetailGetAllQueryHandler(ITenantService tenantService, IMapper mapper)
        {
            _tenantService = tenantService;
            _mapper = mapper;
        }

        public async Task<List<CompanyDetailGetAllDto>> Handle(CompanyDetailGetAllQuery request, CancellationToken cancellationToken)
        {
            var dbContext = await _tenantService.GetDbInstance(cancellationToken);

            return await dbContext
                .CompanyDetails
                .AsNoTracking()
                .Select(x => _mapper.Map<CompanyDetailGetAllDto>(x))
                .ToListAsync(cancellationToken);
        }
    }
}
