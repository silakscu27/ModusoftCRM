using FluentValidation;

namespace ModusoftCRM.Application.Features.Departments.Commands.Add
{
    public class DepartmentAddCommandValidator : AbstractValidator<DepartmentAddCommand>
    {
        public DepartmentAddCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Departman adı boş olamaz.")
                .MaximumLength(100)
                .WithMessage("Departman adı en fazla 100 karakter olabilir.");

            RuleFor(x => x.Description)
                .MaximumLength(500)
                .WithMessage("Açıklama en fazla 500 karakter olabilir.");
        }
    }
}
