using MediatR;

namespace ModusoftCRM.Application.Features.FranchiseRepHistories.Queries.GetById
{
    public class FranchiseRepHistoryGetByIdQuery : IRequest<FranchiseRepHistoryGetByIdDto>
    {
        public int Id { get; set; }

        public FranchiseRepHistoryGetByIdQuery(int id)
        {
            Id = id;
        }
    }
}
