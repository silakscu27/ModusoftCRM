using MediatR;

namespace ModusoftCRM.Application.Features.Projects.Queries.GetById
{
    public class ProjectGetByIdQuery : IRequest<ProjectGetByIdDto>
    {
        public string Id { get; set; }

        public ProjectGetByIdQuery(string id)
        {
            Id = id;
        }
    }
}
