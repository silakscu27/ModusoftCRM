using ModusoftCRM.Domain.Common;

namespace ModusoftCRM.Domain.Entities
{
    public class Employee : EntityBase<Guid>
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

        public string FullName => $"{FirstName} {LastName}";

        public string MobilePhoneNumber { get; set; } = string.Empty;
        public string? WorkPhoneNumber { get; set; }
        public string Email { get; set; } = string.Empty;
        public virtual Department? Department { get; set; }
        public int? DepartmentId { get; set; }
    }
}
