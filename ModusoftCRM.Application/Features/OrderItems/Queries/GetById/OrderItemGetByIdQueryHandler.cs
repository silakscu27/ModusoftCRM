using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ModusoftCRM.Application.Common.Interfaces;

namespace ModusoftCRM.Application.Features.OrderItems.Queries.GetById
{
    public class OrderItemGetByIdQueryHandler : IRequestHandler<OrderItemGetByIdQuery, OrderItemGetByIdDto>
    {
        private readonly ITenantService _tenantService;
        private readonly IMapper _mapper;

        public OrderItemGetByIdQueryHandler(ITenantService tenantService, IMapper mapper)
        {
            _tenantService = tenantService;
            _mapper = mapper;
        }

        public async Task<OrderItemGetByIdDto> Handle(OrderItemGetByIdQuery request, CancellationToken cancellationToken)
        {
            var dbContext = await _tenantService.GetDbInstance(cancellationToken);

            var orderItem = await dbContext.OrderItems
                .AsNoTracking()
                .Include(o => o.ProductVariant)  
                .FirstOrDefaultAsync(x => x.Id == request.OrderItemId, cancellationToken);

            if (orderItem == null)
            {
                throw new KeyNotFoundException("Sipariş öğesi bulunamadı.");
            }

            return _mapper.Map<OrderItemGetByIdDto>(orderItem);
        }
    }
}
