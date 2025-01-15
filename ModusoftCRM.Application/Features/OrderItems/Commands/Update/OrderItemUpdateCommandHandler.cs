using AutoMapper;
using MediatR;
using ModusoftCRM.Application.Common.Interfaces;
using ModusoftCRM.Domain.Common;
using ModusoftCRM.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ModusoftCRM.Application.Features.OrderItems.Commands.Update
{
    public class OrderItemUpdateCommandHandler : IRequestHandler<OrderItemUpdateCommand, Response<int>>
    {
        private readonly ITenantService _tenantService;
        private readonly IMapper _mapper;

        public OrderItemUpdateCommandHandler(ITenantService tenantService, IMapper mapper)
        {
            _tenantService = tenantService;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(OrderItemUpdateCommand request, CancellationToken cancellationToken)
        {
            var dbContext = await _tenantService.GetDbInstance(cancellationToken);

            // find OrderItem in db
            var orderItem = await dbContext.OrderItems.FindAsync(new object[] { request.Id }, cancellationToken);

            if (orderItem == null)
            {
                return new Response<int>(0, "Sipariş öğesi bulunamadı.");
            }

            // update orderitem
            orderItem.ProductVariantId = request.ProductVariantId;
            orderItem.DiscountType = request.DiscountType;
            orderItem.DiscountAmount = request.DiscountAmount;
            orderItem.UnitPrice = request.UnitPrice;
            orderItem.FinalUnitPrice = request.FinalUnitPrice;
            orderItem.Quantity = request.Quantity;

            // save to db
            await dbContext.SaveChangesAsync(cancellationToken);

            return new Response<int>(orderItem.Id, "Sipariş öğesi başarıyla güncellendi.");
        }
    }
}
