using MediatR;

namespace ModusoftCRM.Application.Features.Franchises.Queries.GetById
{
    public class FranchiseGetByIdQuery : IRequest<FranchiseGetByIdDto>
    {
        public Guid Id { get; set; }

        public FranchiseGetByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
