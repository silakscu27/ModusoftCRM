using AutoMapper;
using MediatR;
using ModusoftCRM.Application.Common.Interfaces;
using ModusoftCRM.Domain.Common;
using ModusoftCRM.Domain.Entities;

namespace ModusoftCRM.Application.Features.Franchises.Commands.Add
{
    public class FranchiseAddCommandHandler : IRequestHandler<FranchiseAddCommand, Response<Guid>>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;

        public FranchiseAddCommandHandler(
            IApplicationDbContext dbContext,
            IMapper mapper,
            ICurrentUserService currentUserService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _currentUserService = currentUserService;
        }

        public async Task<Response<Guid>> Handle(FranchiseAddCommand request, CancellationToken cancellationToken)
        {
            var franchise = _mapper.Map<Franchise>(request);

            franchise.CreatedByUserId = _currentUserService.UserId
                ?? throw new ArgumentNullException(nameof(_currentUserService.UserId));
            franchise.CreatedOn = DateTimeOffset.UtcNow;

            var franchiseType = await _dbContext.FranchiseTypes.FindAsync(request.FranchiseTypeId);
            var customer = await _dbContext.Customers.FindAsync(request.CustomerId);

            if (franchiseType == null)
                throw new ArgumentException("Geçerli bir FranchiseType bulunamadı.");
            if (customer == null)
                throw new ArgumentException("Geçerli bir müşteri bulunamadı.");

            await _dbContext.Franchises.AddAsync(franchise, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return new Response<Guid>(franchise.Id, "Franchise başarıyla eklenmiştir.");
        }
    }
}
