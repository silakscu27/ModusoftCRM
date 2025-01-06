using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ModusoftCRM.Application.Common.Interfaces;
using ModusoftCRM.Domain.Common;
using ModusoftCRM.Domain.Entities;

namespace ModusoftCRM.Application.Features.Franchises.Commands.Update
{
    public class FranchiseUpdateCommandHandler : IRequestHandler<FranchiseUpdateCommand, Response<Guid>>
    {
        private readonly ITenantService _tenantService;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;

        public FranchiseUpdateCommandHandler(
            ITenantService tenantService,
            IMapper mapper,
            ICurrentUserService currentUserService)
        {
            _tenantService = tenantService;
            _mapper = mapper;
            _currentUserService = currentUserService;
        }

        public async Task<Response<Guid>> Handle(FranchiseUpdateCommand request, CancellationToken cancellationToken)
        {
            var dbContext = await _tenantService.GetDbInstance(cancellationToken);

            var franchise = await dbContext.Franchises
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (franchise == null)
                return new Response<Guid>(Guid.Empty, $"Franchise (ID: {request.Id}) bulunamadı.");

            _mapper.Map(request, franchise);

            await dbContext.SaveChangesAsync(cancellationToken);

            return new Response<Guid>(franchise.Id, "Franchise başarıyla güncellenmiştir.");
        }
    }
}
