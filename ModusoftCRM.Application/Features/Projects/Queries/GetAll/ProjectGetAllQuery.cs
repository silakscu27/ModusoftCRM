using MediatR;
using System.Collections.Generic;

namespace ModusoftCRM.Application.Features.Projects.Queries.GetAll
{
    public class ProjectGetAllQuery : IRequest<List<ProjectGetAllDto>>
    {
    }
}
