using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ModusoftCRM.Application.Common.Interfaces;

namespace ModusoftCRM.Application.Features.Franchises.Queries.GetAll
{
    public class FranchiseGetAllQueryHandler : IRequestHandler<FranchiseGetAllQuery, List<FranchiseGetAllDto>>
    {
        private readonly ITenantService _tenantService;
        private readonly IMapper _mapper;

        public FranchiseGetAllQueryHandler(ITenantService tenantService, IMapper mapper)
        {
            _tenantService = tenantService;
            _mapper = mapper;
        }

        public async Task<List<FranchiseGetAllDto>> Handle(FranchiseGetAllQuery request, CancellationToken cancellationToken)
        {
            var dbContext = await _tenantService.GetDbInstance(cancellationToken);

            return await dbContext
                .Franchises
                .AsNoTracking()   
                .Select(x => _mapper.Map<FranchiseGetAllDto>(x))
                .ToListAsync(cancellationToken);
        }
    }
}
