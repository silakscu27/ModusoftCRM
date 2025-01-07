using AutoMapper;
using MediatR;
using ModusoftCRM.Application.Common.Interfaces;
using ModusoftCRM.Domain.Common;

namespace ModusoftCRM.Application.Features.Countries.Commands.Update
{
    public class CountryUpdateCommandHandler : IRequestHandler<CountryUpdateCommand, Response<int>>
    {
        private readonly ITenantService _tenantService;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;

        public CountryUpdateCommandHandler(ITenantService tenantService, IMapper mapper, ICurrentUserService currentUserService)
        {
            _tenantService = tenantService;
            _mapper = mapper;
            _currentUserService = currentUserService;
        }

        public async Task<Response<int>> Handle(CountryUpdateCommand request, CancellationToken cancellationToken)
        {
            var dbContext = await _tenantService.GetDbInstance(cancellationToken);

            var country = await dbContext.Countries.FindAsync(new object[] { request.Id }, cancellationToken);

            if (country == null)
            {
                return new Response<int>(0, "Country not found.");
            }

            country.Name = request.Name;
            country.Latitude = request.Latitude;
            country.Longitude = request.Longitude;

            await dbContext.SaveChangesAsync(cancellationToken);

            return new Response<int>(country.Id, "Country successfully updated.");
        }
    }
}
