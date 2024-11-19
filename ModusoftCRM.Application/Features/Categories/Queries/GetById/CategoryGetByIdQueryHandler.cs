using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ModusoftCRM.Application.Common.Interfaces;

namespace ModusoftCRM.Application.Features.Categories.Queries.GetById
{
    public class CategoryGetByIdQueryHandler : IRequestHandler<CategoryGetByIdQuery, CategoryGetByIdDto>
    {
        private readonly ITenantService _tenantService;
        private readonly IMapper _mapper;

        public CategoryGetByIdQueryHandler(ITenantService tenantService, IMapper mapper)
        {
            _tenantService = tenantService;
            _mapper = mapper;
        }

        public async Task<CategoryGetByIdDto> Handle(CategoryGetByIdQuery request, CancellationToken cancellationToken)
        {
            var dbContext = await _tenantService.GetDbInstance(cancellationToken);

            var category = await dbContext.Categories
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            return _mapper.Map<CategoryGetByIdDto>(category);
        }
    }
}