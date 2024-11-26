using MediatR;

namespace ModusoftCRM.Application.Features.Customers.Queries.GetById
{
    public class CustomerGetByIdQuery : IRequest<CustomerGetByIdDto>
    {
        public int Id { get; set; }

        public CustomerGetByIdQuery(int id)
        {
            Id = id;
        }
    }
}
