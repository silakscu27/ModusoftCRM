using AutoMapper;
using MediatR;
using ModusoftCRM.Application.Common.Interfaces;
using ModusoftCRM.Domain.Common;
using ModusoftCRM.Domain.Entities;

namespace CRM.Application.Features.CustomerTypes.Commands.Add
{
    public class CustomerTypeAddCommandHandler : IRequestHandler<CustomerTypeAddCommand, Response<int>>
    {
        private readonly ITenantService _tenantService;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;

        public CustomerTypeAddCommandHandler(ITenantService tenantService, IMapper mapper, ICurrentUserService currentUserService)
        {
            _tenantService = tenantService;
            _mapper = mapper;
            _currentUserService = currentUserService;
        }

        public async Task<Response<int>> Handle(CustomerTypeAddCommand request, CancellationToken cancellationToken)
        {
            var dbContext = await _tenantService.GetDbInstance(cancellationToken);

            var customerType = _mapper.Map<CustomerType>(request);

            customerType.CreatedByUserId = _currentUserService.UserId
                ?? throw new ArgumentNullException(nameof(_currentUserService.UserId)); // Kullanıcı ID kontrolü

            await dbContext.CustomerTypes.AddAsync(customerType, cancellationToken);

            await dbContext.SaveChangesAsync(cancellationToken);

            return new Response<int>(customerType.Id, "Müşteri türü başarıyla eklenmiştir.");
        }
    }
}
