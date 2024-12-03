using AutoMapper;
using CRM.Application.Customers.Commands;
using CRM.Application.Features.CompanyDetails.Commands.Add;
using CRM.Application.Features.CompanyDetails.Commands.Update;
using ModusoftCRM.Application.Features.Categories.Commands.Add;
using ModusoftCRM.Application.Features.Categories.Commands.Update;
using ModusoftCRM.Application.Features.Employees.Commands.Add;
using ModusoftCRM.Domain.Entities;

namespace ModusoftCRM.Application.Mapping
{
    public sealed class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CategoryAddCommand, Category>();
            CreateMap<CategoryUpdateCommand, Category>();

            CreateMap<CustomerAddCommand, Customer>();
            CreateMap<CustomerUpdateCommand, Customer>();

            CreateMap<CompanyDetailAddCommand, CompanyDetail>();
            CreateMap<CompanyDetailUpdateCommand, CompanyDetail>();

            CreateMap<EmployeeAddCommand, Employee>();
        }
    }
}
