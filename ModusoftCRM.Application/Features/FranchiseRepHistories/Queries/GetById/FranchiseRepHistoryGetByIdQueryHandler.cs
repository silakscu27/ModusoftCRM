using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ModusoftCRM.Application.Common.Interfaces;

namespace ModusoftCRM.Application.Features.FranchiseRepHistories.Queries.GetById
{
    public class FranchiseRepHistoryGetByIdQueryHandler : IRequestHandler<FranchiseRepHistoryGetByIdQuery, FranchiseRepHistoryGetByIdDto>
    {
        private readonly ITenantService _tenantService;
        private readonly IMapper _mapper;

        public FranchiseRepHistoryGetByIdQueryHandler(ITenantService tenantService, IMapper mapper)
        {
            _tenantService = tenantService;
            _mapper = mapper;
        }

        public async Task<FranchiseRepHistoryGetByIdDto> Handle(FranchiseRepHistoryGetByIdQuery request, CancellationToken cancellationToken)
        {
            var dbContext = await _tenantService.GetDbInstance(cancellationToken);

            var franchiseRepHistory = await dbContext.FranchiseRepresentativeHistories
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (franchiseRepHistory == null)
            {
                throw new KeyNotFoundException("Franchise temsilci geçmişi bulunamadı.");
            }

            return _mapper.Map<FranchiseRepHistoryGetByIdDto>(franchiseRepHistory);
        }
    }
}
