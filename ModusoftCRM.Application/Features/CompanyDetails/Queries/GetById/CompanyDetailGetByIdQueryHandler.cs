using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ModusoftCRM.Application.Common.Interfaces;
using ModusoftCRM.Domain.Common;

namespace ModusoftCRM.Application.Features.CompanyDetails.Queries.GetById
{
    public class CompanyDetailGetByIdQueryHandler : IRequestHandler<CompanyDetailGetByIdQuery, Response<CompanyDetailGetByIdDto>>
    {
        private readonly ITenantService _tenantService;
        private readonly IMapper _mapper;

        public CompanyDetailGetByIdQueryHandler(ITenantService tenantService, IMapper mapper)
        {
            _tenantService = tenantService;
            _mapper = mapper;
        }

        public async Task<Response<CompanyDetailGetByIdDto>> Handle(CompanyDetailGetByIdQuery request, CancellationToken cancellationToken)
        {
            var dbContext = await _tenantService.GetDbInstance(cancellationToken);

            var companyDetail = await dbContext.CompanyDetails
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (companyDetail == null)
            {
                return new Response<CompanyDetailGetByIdDto>("Company not found");
            }

            var companyDetailDto = _mapper.Map<CompanyDetailGetByIdDto>(companyDetail);
            return new Response<CompanyDetailGetByIdDto>(companyDetailDto);
        }
    }
}
