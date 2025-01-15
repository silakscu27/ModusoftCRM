using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ModusoftCRM.Application.Common.Interfaces;

namespace ModusoftCRM.Application.Features.OrderItems.Queries.GetAll
{
    public class OrderItemGetAllQueryHandler : IRequestHandler<OrderItemGetAllQuery, List<OrderItemGetAllDto>>
    {
        private readonly ITenantService _tenantService;
        private readonly IMapper _mapper;

        public OrderItemGetAllQueryHandler(ITenantService tenantService, IMapper mapper)
        {
            _tenantService = tenantService;
            _mapper = mapper;
        }

        public async Task<List<OrderItemGetAllDto>> Handle(OrderItemGetAllQuery request, CancellationToken cancellationToken)
        {
            var dbContext = await _tenantService.GetDbInstance(cancellationToken);

            return await dbContext
                .OrderItems
                .AsNoTracking()
                .Include(oi => oi.ProductVariant) 
                .Select(oi => _mapper.Map<OrderItemGetAllDto>(oi)) 
                .ToListAsync(cancellationToken);
        }
    }
}
