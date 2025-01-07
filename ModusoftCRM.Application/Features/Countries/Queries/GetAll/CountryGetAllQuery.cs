using MediatR;

namespace ModusoftCRM.Application.Features.Countries.Queries.GetAll
{
    public class CountryGetAllQuery : IRequest<List<CountryGetAllDto>>
    {
    }
}
