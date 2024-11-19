using MediatR;

namespace ModusoftCRM.Application.Features.Categories.Queries.GetById
{
    public class CategoryGetByIdQuery : IRequest<CategoryGetByIdDto>
    {
        public int Id { get; set; }

        public CategoryGetByIdQuery(int id)
        {
            Id = id;
        }
    }
}