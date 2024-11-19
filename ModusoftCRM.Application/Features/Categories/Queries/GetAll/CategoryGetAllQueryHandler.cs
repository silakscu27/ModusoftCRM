using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ModusoftCRM.Application.Common.Interfaces;

namespace ModusoftCRM.Application.Features.Categories.Queries.GetAll
{
    public class CategoryGetAllQueryHandler : IRequestHandler<CategoryGetAllQuery, List<CategoryGetAllDto>>
    {
        private readonly ITenantService _tenantService;
        private readonly IMapper _mapper;

        public CategoryGetAllQueryHandler(ITenantService tenantService, IMapper mapper)
        {
            _tenantService = tenantService;
            _mapper = mapper;
        }

        public async Task<List<CategoryGetAllDto>> Handle(CategoryGetAllQuery request, CancellationToken cancellationToken)
        {
            var dbContext = await _tenantService.GetDbInstance(cancellationToken);

            return await dbContext
                .Categories
                .AsNoTracking()
                .Select(x => _mapper.Map<CategoryGetAllDto>(x))
                .ToListAsync(cancellationToken);
        }
    }
}