using MediatR;
using System.Collections.Generic;

namespace ModusoftCRM.Application.Features.FranchiseTypes.Queries.GetAll
{
    public class FranchiseTypeGetAllQuery : IRequest<List<FranchiseTypeGetAllDto>>
    {
    }
}
