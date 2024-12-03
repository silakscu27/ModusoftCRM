namespace ModusoftCRM.Application.Features.Employees.Queries.GetById
{
    public class EmployeeGetByIdDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string FullName => $"{FirstName} {LastName}";
        public string MobilePhoneNumber { get; set; } = string.Empty;
        public string? WorkPhoneNumber { get; set; }
        public string Email { get; set; } = string.Empty;
        public int? DepartmentId { get; set; }
    }
}
