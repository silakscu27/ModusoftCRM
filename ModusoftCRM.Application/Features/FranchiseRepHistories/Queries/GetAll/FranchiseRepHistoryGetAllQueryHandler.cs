using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ModusoftCRM.Application.Common.Interfaces;

namespace ModusoftCRM.Application.Features.FranchiseRepHistories.Queries.GetAll
{
    public class FranchiseRepHistoryGetAllQueryHandler : IRequestHandler<FranchiseRepHistoryGetAllQuery, List<FranchiseRepHistoryGetAllDto>>
    {
        private readonly ITenantService _tenantService;
        private readonly IMapper _mapper;

        public FranchiseRepHistoryGetAllQueryHandler(ITenantService tenantService, IMapper mapper)
        {
            _tenantService = tenantService;
            _mapper = mapper;
        }

        public async Task<List<FranchiseRepHistoryGetAllDto>> Handle(FranchiseRepHistoryGetAllQuery request, CancellationToken cancellationToken)
        {
            var dbContext = await _tenantService.GetDbInstance(cancellationToken);

            var franchiseRepHistories = await dbContext.FranchiseRepresentativeHistories
                .AsNoTracking()
                .ToListAsync(cancellationToken);

            return _mapper.Map<List<FranchiseRepHistoryGetAllDto>>(franchiseRepHistories);
        }
    }
}
