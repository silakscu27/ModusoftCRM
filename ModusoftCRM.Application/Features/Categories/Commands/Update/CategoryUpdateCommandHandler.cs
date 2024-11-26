using AutoMapper;
using MediatR;
using ModusoftCRM.Application.Common.Interfaces;
using ModusoftCRM.Domain.Common;

namespace ModusoftCRM.Application.Features.Categories.Commands.Update
{
    public class CategoryUpdateCommandHandler : IRequestHandler<CategoryUpdateCommand, Response<int>>
    {
        private readonly ITenantService _tenantService;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;

        public CategoryUpdateCommandHandler(ITenantService tenantService, IMapper mapper, ICurrentUserService currentUserService)
        {
            _tenantService = tenantService;
            _mapper = mapper;
            _currentUserService = currentUserService;
        }

        public async Task<Response<int>> Handle(CategoryUpdateCommand request, CancellationToken cancellationToken)
        {
            var dbContext = await _tenantService.GetDbInstance(cancellationToken);

            var category = await dbContext.Categories.FindAsync(new object[] { request.Id }, cancellationToken);

            if (category == null)
            {
                return new Response<int>(0, "Kategori bulunamadı.");
            }

            category.Name = request.Name;
            category.Description = request.Description;

            await dbContext.SaveChangesAsync(cancellationToken);

            return new Response<int>(category.Id, "Kategori başarıyla güncellendi.");
        }
    }
}