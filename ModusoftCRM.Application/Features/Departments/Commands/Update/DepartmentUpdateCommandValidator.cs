using FluentValidation;

namespace ModusoftCRM.Application.Features.Departments.Commands.Update
{
    public class DepartmentUpdateCommandValidator : AbstractValidator<DepartmentUpdateCommand>
    {
        public DepartmentUpdateCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Lütfen geçerli bir ID giriniz.");

            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Departman adı boş olamaz.")
                .MaximumLength(100)
                .WithMessage("Departman adı 100 karakterden fazla olamaz.");

            RuleFor(x => x.Description)
                .MaximumLength(500)
                .WithMessage("Açıklama 500 karakterden fazla olamaz.");
        }
    }
}
