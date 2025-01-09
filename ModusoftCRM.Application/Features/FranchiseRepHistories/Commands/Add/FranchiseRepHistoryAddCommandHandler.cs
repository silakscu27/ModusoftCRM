using AutoMapper;
using MediatR;
using ModusoftCRM.Application.Common.Interfaces;
using ModusoftCRM.Domain.Common;
using ModusoftCRM.Domain.Entities;

namespace ModusoftCRM.Application.Features.FranchiseRepHistories.Commands.Add
{
    public class FranchiseRepHistoryAddCommandHandler : IRequestHandler<FranchiseRepHistoryAddCommand, Response<int>>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;

        public FranchiseRepHistoryAddCommandHandler(
            IApplicationDbContext dbContext,
            IMapper mapper,
            ICurrentUserService currentUserService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _currentUserService = currentUserService;
        }

        public async Task<Response<int>> Handle(FranchiseRepHistoryAddCommand request, CancellationToken cancellationToken)
        {
            // Entity mapping
            var franchiseRepHistory = _mapper.Map<FranchiseRepresentativeHistory>(request);

            // Creation info
            franchiseRepHistory.CreatedByUserId = _currentUserService.UserId
                ?? throw new ArgumentNullException(nameof(_currentUserService.UserId));
            franchiseRepHistory.CreatedOn = DateTimeOffset.UtcNow;

            // Add to database
            await _dbContext.FranchiseRepresentativeHistories.AddAsync(franchiseRepHistory, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            // Return response
            return new Response<int>(franchiseRepHistory.Id, "Franchise temsilci geçmişi başarıyla eklenmiştir.");
        }
    }
}
