using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ModusoftCRM.Application.Common.Interfaces;
using ModusoftCRM.Domain.Common;
using ModusoftCRM.Domain.Entities;

namespace ModusoftCRM.Application.Features.Employees.Commands.Update
{
    public class EmployeeUpdateCommandHandler : IRequestHandler<EmployeeUpdateCommand, Response<Guid>>
    {
        private readonly ITenantService _tenantService;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;

        public EmployeeUpdateCommandHandler(
            ITenantService tenantService,
            IMapper mapper,
            ICurrentUserService currentUserService)
        {
            _tenantService = tenantService;
            _mapper = mapper;
            _currentUserService = currentUserService;
        }

        public async Task<Response<Guid>> Handle(EmployeeUpdateCommand request, CancellationToken cancellationToken)
        {
            var dbContext = await _tenantService.GetDbInstance(cancellationToken);

            var employee = await dbContext.Employees
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (employee == null)
                return new Response<Guid>(Guid.Empty, $"Çalışan (ID: {request.Id}) bulunamadı.");

            _mapper.Map(request, employee);

            await dbContext.SaveChangesAsync(cancellationToken);

            return new Response<Guid>(employee.Id, "Çalışan Başarıyla Güncellenmiştir");
        }
    }
}
