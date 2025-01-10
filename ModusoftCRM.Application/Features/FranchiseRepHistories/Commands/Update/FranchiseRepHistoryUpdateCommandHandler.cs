using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ModusoftCRM.Application.Common.Interfaces;
using ModusoftCRM.Domain.Common;
using ModusoftCRM.Domain.Entities;

namespace ModusoftCRM.Application.Features.FranchiseRepHistories.Commands.Update
{
    public class FranchiseRepHistoryUpdateCommandHandler : IRequestHandler<FranchiseRepHistoryUpdateCommand, Response<int>>
    {
        private readonly ITenantService _tenantService;
        private readonly IMapper _mapper;

        public FranchiseRepHistoryUpdateCommandHandler(ITenantService tenantService, IMapper mapper)
        {
            _tenantService = tenantService;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(FranchiseRepHistoryUpdateCommand request, CancellationToken cancellationToken)
        {
            var dbContext = await _tenantService.GetDbInstance(cancellationToken);

            var franchiseRepHistory = await dbContext.FranchiseRepresentativeHistories
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (franchiseRepHistory == null)
            {
                return new Response<int>("Franchise Temsilcisi geçmişi bulunamadı.", false);
            }

            franchiseRepHistory.FranchiseRepresentativeId = request.FranchiseRepresentativeId;
            franchiseRepHistory.FranchiseId = request.FranchiseId;
            franchiseRepHistory.From = request.From;
            franchiseRepHistory.To = request.To;
            franchiseRepHistory.Role = request.Role;
            franchiseRepHistory.Description = request.Description;

            dbContext.FranchiseRepresentativeHistories.Update(franchiseRepHistory);
            await dbContext.SaveChangesAsync(cancellationToken);

            return new Response<int>(franchiseRepHistory.Id, "Franchise Temsilcisi geçmişi başarıyla güncellendi.");
        }
    }
}
