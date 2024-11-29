using AutoMapper;
using MediatR;
using ModusoftCRM.Application.Common.Interfaces;
using ModusoftCRM.Domain.Common;
using ModusoftCRM.Domain.Entities;

namespace CRM.Application.Features.CompanyDetails.Commands.Add
{
    public class CompanyDetailAddCommandHandler : IRequestHandler<CompanyDetailAddCommand, Response<int>> // Response<int>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;

        public CompanyDetailAddCommandHandler(
            IApplicationDbContext dbContext,
            IMapper mapper,
            ICurrentUserService currentUserService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _currentUserService = currentUserService;
        }

        public async Task<Response<int>> Handle(CompanyDetailAddCommand request, CancellationToken cancellationToken)
        {
            var companyDetail = _mapper.Map<CompanyDetail>(request);
            companyDetail.CreatedByUserId = _currentUserService.UserId ?? throw new ArgumentNullException(nameof(_currentUserService.UserId));

            await _dbContext.CompanyDetails.AddAsync(companyDetail, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return new Response<int>(companyDetail.Id, "Şirket Detayı Başarıyla Eklenmiştir"); // Id int olduğu için düzenlendi
        }
    }
}
