using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ModusoftCRM.Application.Common.Interfaces;

namespace ModusoftCRM.Application.Features.Customers.Queries.GetAll
{
    public class CustomerGetAllQueryHandler : IRequestHandler<CustomerGetAllQuery, List<CustomerGetAllDto>>
    {
        private readonly ITenantService _tenantService;
        private readonly IMapper _mapper;

        public CustomerGetAllQueryHandler(ITenantService tenantService, IMapper mapper)
        {
            _tenantService = tenantService;
            _mapper = mapper;
        }

        public async Task<List<CustomerGetAllDto>> Handle(CustomerGetAllQuery request, CancellationToken cancellationToken)
        {
            var dbContext = await _tenantService.GetDbInstance(cancellationToken);

            return await dbContext
                .Customers
                .AsNoTracking() 
                .Select(x => _mapper.Map<CustomerGetAllDto>(x))
                .ToListAsync(cancellationToken); 
        }
    }
}
