using MediatR;
using System.Collections.Generic;

namespace ModusoftCRM.Application.Features.FranchiseRepresentatives.Queries.GetAll
{
    public class FranchiseRepresentativeGetAllQuery : IRequest<List<FranchiseRepresentativeGetAllDto>>
    {
    }
}
