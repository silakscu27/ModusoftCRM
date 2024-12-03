using FluentValidation;

namespace ModusoftCRM.Application.Features.Employees.Commands.Update
{
    public class EmployeeUpdateCommandValidator : AbstractValidator<EmployeeUpdateCommand>
    {
        public EmployeeUpdateCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Çalışan ID boş olamaz.");
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("Ad boş olamaz.");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Soyad boş olamaz.");
            RuleFor(x => x.Email).NotEmpty().EmailAddress().WithMessage("Geçerli bir e-posta adresi giriniz.");
            RuleFor(x => x.MobilePhoneNumber).NotEmpty().WithMessage("Telefon numarası boş olamaz.");
        }
    }
}
