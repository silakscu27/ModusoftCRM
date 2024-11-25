using AutoMapper;
using CRM.Application.Customers.Commands;
using MediatR;
using ModusoftCRM.Application.Common.Interfaces;
using ModusoftCRM.Domain.Common;
using ModusoftCRM.Domain.Entities;

namespace CRM.Application.Features.Customers.Commands.Update
{
    public class CustomerUpdateCommandHandler : IRequestHandler<CustomerUpdateCommand, Response<Guid>>
    {
        private readonly ITenantService _tenantService;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;

        public CustomerUpdateCommandHandler(ITenantService tenantService, IMapper mapper, ICurrentUserService currentUserService)
        {
            _tenantService = tenantService;
            _mapper = mapper;
            _currentUserService = currentUserService;
        }

        public async Task<Response<Guid>> Handle(CustomerUpdateCommand request, CancellationToken cancellationToken)
        {
            var dbContext = await _tenantService.GetDbInstance(cancellationToken);

            var customer = await dbContext.Customers.FindAsync(new object[] { request.Id }, cancellationToken);

            if (customer == null)
            {
                return new Response<Guid>(Guid.Empty, "Müşteri bulunamadı.");
            }

            // Güncelleme işlemleri
            customer.Name = request.Name;
            customer.Description = request.Description;
            customer.ErpId = request.ErpId;

            if (request.RemovePicture)
            {
                customer.Picture = null;
            }
            else if (!string.IsNullOrEmpty(request.NewPicture))
            {
                customer.Picture = request.NewPicture;
            }

            await dbContext.SaveChangesAsync(cancellationToken);

            return new Response<Guid>(customer.Id, "Müşteri başarıyla güncellendi.");
        }

    }
}
