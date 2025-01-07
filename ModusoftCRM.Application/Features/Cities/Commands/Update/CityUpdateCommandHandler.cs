using AutoMapper;
using MediatR;
using ModusoftCRM.Application.Common.Interfaces;
using ModusoftCRM.Domain.Common;

namespace ModusoftCRM.Application.Features.Cities.Commands.Update
{
    public class CityUpdateCommandHandler : IRequestHandler<CityUpdateCommand, Response<int>>
    {
        private readonly ITenantService _tenantService;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;

        public CityUpdateCommandHandler(ITenantService tenantService, IMapper mapper, ICurrentUserService currentUserService)
        {
            _tenantService = tenantService;
            _mapper = mapper;
            _currentUserService = currentUserService;
        }

        public async Task<Response<int>> Handle(CityUpdateCommand request, CancellationToken cancellationToken)
        {
            var dbContext = await _tenantService.GetDbInstance(cancellationToken);

            var city = await dbContext.Cities.FindAsync(new object[] { request.Id }, cancellationToken);

            if (city == null)
            {
                return new Response<int>(0, "City not found.");
            }

            city.Name = request.Name;
            city.Latitude = request.Latitude;
            city.Longitude = request.Longitude;
            city.CountryId = request.CountryId;

            await dbContext.SaveChangesAsync(cancellationToken);

            return new Response<int>(city.Id, "City successfully updated.");
        }
    }
}
