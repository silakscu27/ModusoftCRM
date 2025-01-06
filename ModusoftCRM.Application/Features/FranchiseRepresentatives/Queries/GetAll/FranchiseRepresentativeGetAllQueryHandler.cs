using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ModusoftCRM.Application.Common.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ModusoftCRM.Application.Features.FranchiseRepresentatives.Queries.GetAll
{
    public class FranchiseRepresentativeGetAllQueryHandler : IRequestHandler<FranchiseRepresentativeGetAllQuery, List<FranchiseRepresentativeGetAllDto>>
    {
        private readonly ITenantService _tenantService;
        private readonly IMapper _mapper;

        public FranchiseRepresentativeGetAllQueryHandler(ITenantService tenantService, IMapper mapper)
        {
            _tenantService = tenantService;
            _mapper = mapper;
        }

        public async Task<List<FranchiseRepresentativeGetAllDto>> Handle(FranchiseRepresentativeGetAllQuery request, CancellationToken cancellationToken)
        {
            var dbContext = await _tenantService.GetDbInstance(cancellationToken);

            var franchiseRepresentatives = await dbContext.FranchiseRepresentatives
                .AsNoTracking()
                .ToListAsync(cancellationToken);

            return _mapper.Map<List<FranchiseRepresentativeGetAllDto>>(franchiseRepresentatives);
        }
    }
}
