using MediatR;
using ModusoftCRM.Domain.Common;

namespace CRM.Application.Customers.Commands
{
    public class CustomerUpdateCommand : IRequest<Response<Guid>>
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? ErpId { get; set; }
        public string? Picture { get; set; }
        public string? NewPicture { get; set; }
        public string? NewPictureName { get; set; }
        public List<Guid> CustomerTypeIds { get; set; } = new();
        public bool RemovePicture { get; set; } = false;
    }
}
