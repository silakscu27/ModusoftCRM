using MediatR;
using ModusoftCRM.Domain.Common;

namespace ModusoftCRM.Application.Features.Cities.Queries.GetById
{
    public class CityGetByIdQuery : IRequest<Response<CityGetByIdDto>>
    {
        public int Id { get; set; }

        public CityGetByIdQuery(int id)
        {
            Id = id;
        }
    }
}
