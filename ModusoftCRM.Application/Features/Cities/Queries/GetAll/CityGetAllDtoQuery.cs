using MediatR;
using System.Collections.Generic;

namespace ModusoftCRM.Application.Features.Cities.Queries.GetAll
{
    public class CityGetAllQuery : IRequest<List<CityGetAllDto>>
    {
    }
}
