using MediatR;
using ModusoftCRM.Domain.Common;


namespace CRM.Application.Customers.Commands
{
    public class CustomerAddCommand : IRequest<Response<int>>
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? ErpId { get; set; }
        public string? Picture { get; set; }
        public string? PictureName { get; set; }
        public List<Guid> CustomerTypeIds { get; set; } = new();
        public bool AddFranchise { get; set; } = true;
    }
}
