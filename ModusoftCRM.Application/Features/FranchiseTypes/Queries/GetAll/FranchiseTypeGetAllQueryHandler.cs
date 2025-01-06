using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ModusoftCRM.Application.Common.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ModusoftCRM.Application.Features.FranchiseTypes.Queries.GetAll
{
    public class FranchiseTypeGetAllQueryHandler : IRequestHandler<FranchiseTypeGetAllQuery, List<FranchiseTypeGetAllDto>>
    {
        private readonly ITenantService _tenantService;
        private readonly IMapper _mapper;

        public FranchiseTypeGetAllQueryHandler(ITenantService tenantService, IMapper mapper)
        {
            _tenantService = tenantService;
            _mapper = mapper;
        }

        public async Task<List<FranchiseTypeGetAllDto>> Handle(FranchiseTypeGetAllQuery request, CancellationToken cancellationToken)
        {
            var dbContext = await _tenantService.GetDbInstance(cancellationToken);

            var franchiseTypes = await dbContext.FranchiseTypes
                .AsNoTracking()
                .ToListAsync(cancellationToken);

            return _mapper.Map<List<FranchiseTypeGetAllDto>>(franchiseTypes);
        }
    }
}
