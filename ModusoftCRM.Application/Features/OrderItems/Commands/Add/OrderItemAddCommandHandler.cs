using AutoMapper;
using MediatR;
using ModusoftCRM.Application.Common.Interfaces;
using ModusoftCRM.Domain.Common;
using ModusoftCRM.Domain.Entities;
using ModusoftCRM.Domain.Enums;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ModusoftCRM.Application.Features.OrderItems.Commands.Add
{
    public class OrderItemAddCommandHandler : IRequestHandler<OrderItemAddCommand, Response<int>>
    {
        private readonly ITenantService _tenantService;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;

        public OrderItemAddCommandHandler(ITenantService tenantService, IMapper mapper, ICurrentUserService currentUserService)
        {
            _tenantService = tenantService;
            _mapper = mapper;
            _currentUserService = currentUserService;
        }

        public async Task<Response<int>> Handle(OrderItemAddCommand request, CancellationToken cancellationToken)
        {
            var dbContext = await _tenantService.GetDbInstance(cancellationToken);

            var orderItem = _mapper.Map<OrderItem>(request);

            orderItem.CreatedByUserId = _currentUserService.UserId
                ?? throw new ArgumentNullException(nameof(_currentUserService.UserId)); // Kullanıcı ID kontrolü

            await dbContext.OrderItems.AddAsync(orderItem, cancellationToken);
            await dbContext.SaveChangesAsync(cancellationToken);

            return new Response<int>(orderItem.Id, "Sipariş öğesi başarıyla eklenmiştir.");
        }
    }
}
