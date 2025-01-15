using MediatR;
using ModusoftCRM.Domain.Common;
using ModusoftCRM.Domain.Enums;

namespace ModusoftCRM.Application.Features.Orders.Commands.Update
{
    public class OrderUpdateCommand : IRequest<Response<Guid>>
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? No { get; set; }
        public OrderStatus Status { get; set; }
        public CurrencyCode Currency { get; set; }
        public DateTimeOffset Date { get; set; }
        public DateTimeOffset ValidityDate { get; set; }
        public string? ShortDescription { get; set; }
        public string? Details { get; set; }
        public int TaxRate { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal FinalAmount { get; set; }
    }
}
