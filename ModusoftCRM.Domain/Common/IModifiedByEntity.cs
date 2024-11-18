namespace ModusoftCRM.Domain.Common
{
    public interface IModifiedByEntity
    {
        public string? ModifiedByUserId { get; set; }
        public DateTimeOffset? LastModifiedOn { get; set; }
    }
}