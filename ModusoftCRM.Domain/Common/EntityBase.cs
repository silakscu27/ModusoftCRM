namespace ModusoftCRM.Domain.Common
{
    public abstract class EntityBase<TKey> : IEntityBase<TKey>, ICreatedByEntity, IModifiedByEntity, IDeletedByEntity
    {
        public virtual required TKey Id { get; set; }

        public virtual required string CreatedByUserId { get; set; }
        public virtual DateTimeOffset CreatedOn { get; set; }
        public virtual string? ModifiedByUserId { get; set; }
        public virtual DateTimeOffset? LastModifiedOn { get; set; }
        public bool IsDeleted { get; set; }
        public virtual string? DeletedByUserId { get; set; }
        public virtual DateTimeOffset? DeletedOn { get; set; }
    }
}