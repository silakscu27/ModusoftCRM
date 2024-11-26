using MediatR;

namespace ModusoftCRM.Application.Features.Customers.Queries.GetById
{
    public class CustomerGetByIdQuery : IRequest<CustomerGetByIdDto>
    {
        public Guid Id { get; set; }

        public CustomerGetByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
