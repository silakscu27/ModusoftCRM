﻿using ModusoftCRM.Domain.Enums;

namespace ModusoftCRM.Application.Features.Orders.Queries.GetById
{
    public class OrderGetByIdDto
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
        public string? UserId { get; set; }
        public int TaxRate { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal FinalAmount { get; set; }
        public List<OrderItemDto> OrderItems { get; set; } = new List<OrderItemDto>(); 
    }

    public class OrderItemDto
    {
        public string ProductVariantId { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal FinalUnitPrice { get; set; }
    }
}