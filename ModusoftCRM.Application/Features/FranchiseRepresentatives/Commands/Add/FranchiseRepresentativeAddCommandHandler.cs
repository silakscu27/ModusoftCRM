using AutoMapper;
using MediatR;
using ModusoftCRM.Application.Common.Interfaces;
using ModusoftCRM.Domain.Common;
using ModusoftCRM.Domain.Entities;

namespace ModusoftCRM.Application.Features.FranchiseRepresentatives.Commands.Add
{
    public class FranchiseRepresentativeAddCommandHandler : IRequestHandler<FranchiseRepresentativeAddCommand, Response<Guid>>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;

        public FranchiseRepresentativeAddCommandHandler(
            IApplicationDbContext dbContext,
            IMapper mapper,
            ICurrentUserService currentUserService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _currentUserService = currentUserService;
        }

        public async Task<Response<Guid>> Handle(FranchiseRepresentativeAddCommand request, CancellationToken cancellationToken)
        {
            var franchiseRepresentative = _mapper.Map<FranchiseRepresentative>(request);

            franchiseRepresentative.CreatedByUserId = _currentUserService.UserId
                ?? throw new ArgumentNullException(nameof(_currentUserService.UserId));
            franchiseRepresentative.CreatedOn = DateTimeOffset.UtcNow;

            await _dbContext.FranchiseRepresentatives.AddAsync(franchiseRepresentative, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return new Response<Guid>(franchiseRepresentative.Id, "Franchise temsilcisi başarıyla eklenmiştir.");
        }
    }
}
