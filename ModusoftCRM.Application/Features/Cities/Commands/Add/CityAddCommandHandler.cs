using AutoMapper;
using MediatR;
using ModusoftCRM.Application.Common.Interfaces;
using ModusoftCRM.Domain.Common;
using ModusoftCRM.Domain.Entities;

namespace ModusoftCRM.Application.Features.Cities.Commands.Add
{
    public class CityAddCommandHandler : IRequestHandler<CityAddCommand, Response<int>>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;

        public CityAddCommandHandler(
            IApplicationDbContext dbContext,
            IMapper mapper,
            ICurrentUserService currentUserService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _currentUserService = currentUserService;
        }

        public async Task<Response<int>> Handle(CityAddCommand request, CancellationToken cancellationToken)
        {
            var city = _mapper.Map<City>(request);
            city.CreatedByUserId = _currentUserService.UserId ?? throw new ArgumentNullException(nameof(_currentUserService.UserId));

            await _dbContext.Cities.AddAsync(city, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return new Response<int>(city.Id, "Şehir başarıyla eklenmiştir.");
        }
    }
}
