using AutoMapper;
using ModusoftCRM.Application.Features.Categories.Commands.Add;
using ModusoftCRM.Domain.Entities;

namespace ModusoftCRM.Application.Mapping
{
    public sealed class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CategoryAddCommand, Category>();
        }
    }
}
