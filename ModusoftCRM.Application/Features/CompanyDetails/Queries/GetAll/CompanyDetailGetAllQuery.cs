using MediatR;
using System.Collections.Generic;

namespace ModusoftCRM.Application.Features.CompanyDetails.Queries.GetAll
{
    public class CompanyDetailGetAllQuery : IRequest<List<CompanyDetailGetAllDto>>
    {
    }
}
