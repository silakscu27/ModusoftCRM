using AutoMapper;
using MediatR;
using ModusoftCRM.Application.Common.Interfaces;
using ModusoftCRM.Domain.Common;
using ModusoftCRM.Domain.Entities;

namespace ModusoftCRM.Application.Features.Categories.Commands.Add
{
    public class CategoryAddCommandHandler : IRequestHandler<CategoryAddCommand, Response<int>>
    {
        private readonly ITenantService _tenantService;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;

        public CategoryAddCommandHandler(ITenantService tenantService, IMapper mapper, ICurrentUserService currentUserService)
        {
            _tenantService = tenantService;
            _mapper = mapper;
            _currentUserService = currentUserService;
        }
        public async Task<Response<int>> Handle(CategoryAddCommand request, CancellationToken cancellationToken)
        {
            var dbContext = await _tenantService.GetDbInstance(cancellationToken);

            var category = _mapper.Map<Category>(request);

            category.CreatedByUserId = _currentUserService.UserId ?? throw new ArgumentNullException(nameof(_currentUserService.UserId)); // Possible null reference assignment error

            await dbContext.Categories.AddAsync(category, cancellationToken);

            await dbContext.SaveChangesAsync(cancellationToken);

            return new Response<int>(category.Id, "Kategori Başarıyla Eklemiştir");
        }
    }
}