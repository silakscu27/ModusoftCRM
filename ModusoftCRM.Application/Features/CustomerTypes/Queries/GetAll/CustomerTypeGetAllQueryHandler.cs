using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ModusoftCRM.Application.Common.Interfaces;

namespace ModusoftCRM.Application.Features.CustomerTypes.Queries.GetAll
{
    public class CustomerTypeGetAllQueryHandler : IRequestHandler<CustomerTypeGetAllQuery, List<CustomerTypeGetAllDto>>
    {
        private readonly ITenantService _tenantService;
        private readonly IMapper _mapper;

        public CustomerTypeGetAllQueryHandler(ITenantService tenantService, IMapper mapper)
        {
            _tenantService = tenantService;
            _mapper = mapper;
        }

        public async Task<List<CustomerTypeGetAllDto>> Handle(CustomerTypeGetAllQuery request, CancellationToken cancellationToken)
        {
            var dbContext = await _tenantService.GetDbInstance(cancellationToken);

            return await dbContext
                .CustomerTypes 
                .AsNoTracking() 
                .Select(x => _mapper.Map<CustomerTypeGetAllDto>(x)) 
                .ToListAsync(cancellationToken); 
        }
    }
}
