using MediatR;

namespace ModusoftCRM.Application.Features.Countries.Queries.GetById
{
    public class CountryGetByIdQuery : IRequest<CountryGetByIdDto>
    {
        public int Id { get; set; }

        public CountryGetByIdQuery(int id)
        {
            Id = id;
        }
    }
}
