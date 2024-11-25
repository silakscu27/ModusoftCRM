using AutoMapper;
using CRM.Application.Customers.Commands;
using ModusoftCRM.Application.Features.Categories.Commands.Add;
using ModusoftCRM.Application.Features.Categories.Commands.Update;
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
        }
    }
}
