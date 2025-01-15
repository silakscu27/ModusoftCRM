namespace ModusoftCRM.Domain.Enums
{
    public enum OrderStatus
    {
        Draft = 0,
        Created = 1,
        Processing = 2,
        WaitingForPayment = 3,
        Cancelled = 4,
        Shipped = 5,
    }
}