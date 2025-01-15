using AutoMapper;
using MediatR;
using ModusoftCRM.Application.Common.Interfaces;
using ModusoftCRM.Domain.Common;
using ModusoftCRM.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ModusoftCRM.Application.Features.Orders.Commands.Update
{
    public class OrderUpdateCommandHandler : IRequestHandler<OrderUpdateCommand, Response<Guid>>
    {
        private readonly ITenantService _tenantService;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;

        public OrderUpdateCommandHandler(ITenantService tenantService, IMapper mapper, ICurrentUserService currentUserService)
        {
            _tenantService = tenantService;
            _mapper = mapper;
            _currentUserService = currentUserService;
        }

        public async Task<Response<Guid>> Handle(OrderUpdateCommand request, CancellationToken cancellationToken)
        {
            var dbContext = await _tenantService.GetDbInstance(cancellationToken);

            // find order
            var order = await dbContext.Orders.FindAsync(new object[] { request.Id }, cancellationToken);

            if (order == null)
            {
                return new Response<Guid>(Guid.Empty, "Sipariş bulunamadı.");
            }

            // Update order
            order.Name = request.Name;
            order.Description = request.Description;
            order.No = request.No;
            order.Status = request.Status;
            order.Currency = request.Currency;
            order.Date = request.Date;
            order.ValidityDate = request.ValidityDate;
            order.ShortDescription = request.ShortDescription;
            order.Details = request.Details;
            order.TaxRate = request.TaxRate;
            order.TotalAmount = request.TotalAmount;
            order.FinalAmount = request.FinalAmount;

            // save to db
            await dbContext.SaveChangesAsync(cancellationToken);

            return new Response<Guid>(order.Id, "Sipariş başarıyla güncellendi.");
        }
    }
}
