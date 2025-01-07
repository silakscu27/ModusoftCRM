using AutoMapper;
using MediatR;
using ModusoftCRM.Application.Common.Interfaces;
using ModusoftCRM.Domain.Common;
using ModusoftCRM.Domain.Entities;

namespace ModusoftCRM.Application.Features.Countries.Commands.Add
{
    public class CountryAddCommandHandler : IRequestHandler<CountryAddCommand, Response<int>>
    {
        private readonly ITenantService _tenantService;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;

        public CountryAddCommandHandler(ITenantService tenantService, IMapper mapper, ICurrentUserService currentUserService)
        {
            _tenantService = tenantService;
            _mapper = mapper;
            _currentUserService = currentUserService;
        }

        public async Task<Response<int>> Handle(CountryAddCommand request, CancellationToken cancellationToken)
        {
            var dbContext = await _tenantService.GetDbInstance(cancellationToken);

            var country = _mapper.Map<Country>(request);
            country.CreatedByUserId = _currentUserService.UserId ?? throw new ArgumentNullException(nameof(_currentUserService.UserId));

            await dbContext.Countries.AddAsync(country, cancellationToken);
            await dbContext.SaveChangesAsync(cancellationToken);

            return new Response<int>(country.Id, "Ülke başarıyla eklendi.");
        }
    }
}
