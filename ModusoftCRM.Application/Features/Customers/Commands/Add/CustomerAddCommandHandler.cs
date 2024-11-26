using AutoMapper;
using MediatR;
using ModusoftCRM.Application.Common.Interfaces;
using ModusoftCRM.Domain.Common;
using CRM.Application.Customers.Commands;
using ModusoftCRM.Domain.Entities;

namespace CRM.Application.Features.Customers.Commands.Add
{
    public class CustomerAddCommandHandler : IRequestHandler<CustomerAddCommand, Response<int>>
    {
        private readonly ITenantService _tenantService;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;

        public CustomerAddCommandHandler(ITenantService tenantService, IMapper mapper, ICurrentUserService currentUserService)
        {
            _tenantService = tenantService;
            _mapper = mapper;
            _currentUserService = currentUserService;
        }

        public async Task<Response<int>> Handle(CustomerAddCommand request, CancellationToken cancellationToken)
        {
            var dbContext = await _tenantService.GetDbInstance(cancellationToken);

            var customer = _mapper.Map<Customer>(request);

            customer.CreatedByUserId = _currentUserService.UserId
                ?? throw new ArgumentNullException(nameof(_currentUserService.UserId)); // Kullanıcı ID kontrolü

            await dbContext.Customers.AddAsync(customer, cancellationToken);

            await dbContext.SaveChangesAsync(cancellationToken);

            return new Response<int>(customer.Id, "Müşteri başarıyla eklenmiştir.");
        }
    }
}
