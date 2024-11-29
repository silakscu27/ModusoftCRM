using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ModusoftCRM.Domain.Entities;
using ModusoftCRM.Application.Common.Interfaces;
using ModusoftCRM.Domain.Common;

namespace CRM.Application.Features.CompanyDetails.Commands.Update
{
    public class CompanyDetailUpdateCommandHandler : IRequestHandler<CompanyDetailUpdateCommand, Response<int>>
    {
        private readonly ITenantService _tenantService;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;

        public CompanyDetailUpdateCommandHandler(
            ITenantService tenantService,
            IMapper mapper,
            ICurrentUserService currentUserService)
        {
            _tenantService = tenantService;
            _mapper = mapper;
            _currentUserService = currentUserService;
        }

        public async Task<Response<int>> Handle(CompanyDetailUpdateCommand request, CancellationToken cancellationToken)
        {
            var dbContext = await _tenantService.GetDbInstance(cancellationToken);
            var companyDetail = await dbContext.CompanyDetails
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (companyDetail == null)
                return new Response<int>(0, $"Şirket detayı (ID: {request.Id}) bulunamadı.");

            _mapper.Map(request, companyDetail);

            await dbContext.SaveChangesAsync(cancellationToken);

            return new Response<int>(companyDetail.Id, "Şirket Detayı Başarıyla Güncellenmiştir");
        }
    }
}
