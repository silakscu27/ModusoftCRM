using AutoMapper;
using CRM.Application.Customers.Commands;
using CRM.Application.Features.CompanyDetails.Commands.Add;
using CRM.Application.Features.CompanyDetails.Commands.Update;
using CRM.Application.Features.CustomerTypes.Commands.Add;
using ModusoftCRM.Application.Features.Categories.Commands.Add;
using ModusoftCRM.Application.Features.Categories.Commands.Update;
using ModusoftCRM.Application.Features.Cities.Commands.Add;
using ModusoftCRM.Application.Features.Cities.Commands.Update;
using ModusoftCRM.Application.Features.Countries.Commands.Add;
using ModusoftCRM.Application.Features.Countries.Commands.Update;
using ModusoftCRM.Application.Features.Departments.Commands.Add;
using ModusoftCRM.Application.Features.Departments.Commands.Update;
using ModusoftCRM.Application.Features.Employees.Commands.Add;
using ModusoftCRM.Application.Features.Employees.Commands.Update;
using ModusoftCRM.Application.Features.FranchiseRepHistories.Commands.Add;
using ModusoftCRM.Application.Features.FranchiseRepHistories.Commands.Update;
using ModusoftCRM.Application.Features.FranchiseRepresentatives.Commands.Add;
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

            CreateMap<CustomerTypeAddCommand, CustomerType>();

            CreateMap<CompanyDetailAddCommand, CompanyDetail>();
            CreateMap<CompanyDetailUpdateCommand, CompanyDetail>();

            CreateMap<EmployeeAddCommand, Employee>();
            CreateMap<EmployeeUpdateCommand, Employee>();

            CreateMap<DepartmentAddCommand, Department>();
            CreateMap<DepartmentUpdateCommand, Department>();

            CreateMap<ProductAddCommand, Product>();
            CreateMap<ProductUpdateCommand, Product>();

            CreateMap<FranchiseAddCommand, Franchise>();
            CreateMap<FranchiseUpdateCommand, Franchise>();

            CreateMap<FranchiseRepresentativeAddCommand, FranchiseRepresentative>();

            CreateMap<CountryAddCommand, Country>();
            CreateMap<CountryUpdateCommand, Country>();

            CreateMap<CityAddCommand, City>();
            CreateMap<CityUpdateCommand, City>();

            CreateMap<FranchiseRepHistoryAddCommand, FranchiseRepresentativeHistory>();
            CreateMap<FranchiseRepHistoryUpdateCommand, FranchiseRepresentativeHistory>();
        }
    }
}
