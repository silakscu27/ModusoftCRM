using FluentValidation;

namespace ModusoftCRM.Application.Features.Employees.Commands.Add
{
    public class EmployeeAddCommandValidator : AbstractValidator<EmployeeAddCommand>
    {
        public EmployeeAddCommandValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("Ad boş geçilemez.")
                .MaximumLength(50).WithMessage("Ad 50 karakterden uzun olamaz.");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Soyad boş geçilemez.")
                .MaximumLength(50).WithMessage("Soyad 50 karakterden uzun olamaz.");

            RuleFor(x => x.MobilePhoneNumber)
                .NotEmpty().WithMessage("Mobil telefon numarası boş geçilemez.")
                .Matches(@"^\+?\d{10,15}$")
                .WithMessage("Geçerli bir mobil telefon numarası giriniz.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email adresi boş geçilemez.")
                .EmailAddress().WithMessage("Geçerli bir email adresi giriniz.");

            RuleFor(x => x.DepartmentId)
                .GreaterThan(0).When(x => x.DepartmentId.HasValue)
                .WithMessage("Departman ID geçerli bir değer olmalıdır.");
        }
    }
}
