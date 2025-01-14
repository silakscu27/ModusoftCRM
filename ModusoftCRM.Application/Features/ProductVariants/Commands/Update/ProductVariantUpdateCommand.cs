using MediatR;
using ModusoftCRM.Domain.Common;

namespace ModusoftCRM.Application.Features.ProductVariants.Commands.Update
{
    public class ProductVariantUpdateCommand : IRequest<Response<Guid>>
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public decimal? Price { get; set; }
        public int? Stock { get; set; }
        public Guid? ProductId { get; set; }
    }
}
