using MediatR;
using ModusoftCRM.Domain.Common;
using ModusoftCRM.Domain.Enums;
using System;

namespace ModusoftCRM.Application.Features.ProductVariantUnitPrices.Commands.Update
{
    public class ProductVariantUnitPriceUpdateCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string ProductVariantId { get; set; } = string.Empty;
        public Guid FranchiseTypeId { get; set; }
        public string FranchiseTypeName { get; set; } = string.Empty;
        public DiscountType DiscountType { get; set; }
        public double DiscountAmount { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
