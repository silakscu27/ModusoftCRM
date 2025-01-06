using AutoMapper;
using CRM.Application.Customers.Commands;
using CRM.Application.Features.CompanyDetails.Commands.Add;
using CRM.Application.Features.CompanyDetails.Commands.Update;
using ModusoftCRM.Application.Features.Categories.Commands.Add;
using ModusoftCRM.Application.Features.Categories.Commands.Update;
using ModusoftCRM.Application.Features.Departments.Commands.Add;
using ModusoftCRM.Application.Features.Departments.Commands.Update;
using ModusoftCRM.Application.Features.Employees.Commands.Add;
using ModusoftCRM.Application.Features.Employees.Commands.Update;
using ModusoftCRM.Application.Features.Franchises.Commands.Add;
using ModusoftCRM.Application.Features.Franchises.Commands.Update;
using ModusoftCRM.Application.Features.Products.Commands.Add;
using ModusoftCRM.Application.Features.Products.Commands.Update;
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

            CreateMap<EmployeeUpdateCommand, Employee>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.MobilePhoneNumber, opt => opt.MapFrom(src => src.MobilePhoneNumber))
                .ForMember(dest => dest.WorkPhoneNumber, opt => opt.MapFrom(src => src.WorkPhoneNumber))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Department, opt => opt.MapFrom(src => src.DepartmentId));

            CreateMap<DepartmentAddCommand, Department>();
            CreateMap<DepartmentUpdateCommand, Department>();

            CreateMap<ProductAddCommand, Product>();
            CreateMap<ProductUpdateCommand, Product>();

            CreateMap<FranchiseAddCommand, Franchise>();
            CreateMap<FranchiseUpdateCommand, Franchise>();
        }
    }
}
