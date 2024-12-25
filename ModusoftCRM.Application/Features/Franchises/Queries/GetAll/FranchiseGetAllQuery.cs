using MediatR;

namespace ModusoftCRM.Application.Features.Franchises.Queries.GetAll
{
    public class FranchiseGetAllQuery : IRequest<List<FranchiseGetAllDto>>
    {
    }
}
