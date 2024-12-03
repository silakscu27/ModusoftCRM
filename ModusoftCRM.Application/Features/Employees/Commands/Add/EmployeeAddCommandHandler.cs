using AutoMapper;
using MediatR;
using ModusoftCRM.Application.Common.Interfaces;
using ModusoftCRM.Domain.Common;
using ModusoftCRM.Domain.Entities;

namespace ModusoftCRM.Application.Features.Employees.Commands.Add
{
    public class EmployeeAddCommandHandler : IRequestHandler<EmployeeAddCommand, Response<Guid>> // Response<Guid> olarak düzenlendi
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;

        public EmployeeAddCommandHandler(
            IApplicationDbContext dbContext,
            IMapper mapper,
            ICurrentUserService currentUserService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _currentUserService = currentUserService;
        }

        public async Task<Response<Guid>> Handle(EmployeeAddCommand request, CancellationToken cancellationToken)
        {
            // Employee nesnesi oluşturuluyor
            var employee = _mapper.Map<Employee>(request);

            // Oluşturma bilgileri ayarlanıyor
            employee.CreatedByUserId = _currentUserService.UserId
                ?? throw new ArgumentNullException(nameof(_currentUserService.UserId));
            employee.CreatedOn = DateTimeOffset.UtcNow;

            // Veritabanına ekleme işlemi
            await _dbContext.Employees.AddAsync(employee, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            // Yanıt olarak Employee.Id dönülüyor
            return new Response<Guid>(employee.Id, "Çalışan başarıyla eklenmiştir.");
        }
    }
}
