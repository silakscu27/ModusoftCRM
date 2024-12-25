using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ModusoftCRM.Application.Common.Interfaces;

namespace ModusoftCRM.Application.Features.Franchises.Queries.GetById
{
    public class FranchiseGetByIdQueryHandler : IRequestHandler<FranchiseGetByIdQuery, FranchiseGetByIdDto>
    {
        private readonly ITenantService _tenantService;
        private readonly IMapper _mapper;

        public FranchiseGetByIdQueryHandler(ITenantService tenantService, IMapper mapper)
        {
            _tenantService = tenantService;
            _mapper = mapper;
        }

        public async Task<FranchiseGetByIdDto> Handle(FranchiseGetByIdQuery request, CancellationToken cancellationToken)
        {
            var dbContext = await _tenantService.GetDbInstance(cancellationToken);

            var franchise = await dbContext.Franchises
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (franchise == null)
            {
                throw new KeyNotFoundException("Franchise bulunamadı.");
            }

            return _mapper.Map<FranchiseGetByIdDto>(franchise);
        }
    }
}
