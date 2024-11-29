using MediatR;
using ModusoftCRM.Domain.Common;

namespace ModusoftCRM.Application.Features.CompanyDetails.Queries.GetById
{
    public class CompanyDetailGetByIdQuery : IRequest<Response<CompanyDetailGetByIdDto>>
    {
        public int Id { get; set; }

        public CompanyDetailGetByIdQuery(int id)
        {
            Id = id;
        }
    }
}
