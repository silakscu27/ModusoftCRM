using FluentValidation;
using ModusoftCRM.Application.Features.Projects.Commands.Add;

namespace ModusoftCRM.Application.Features.Projects.Commands.Add
{
    public class ProjectAddCommandValidator : AbstractValidator<ProjectAddCommand>
    {
        public ProjectAddCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Proje adı boş geçilemez.")
                .MaximumLength(100)
                .WithMessage("Proje adı en fazla 100 karakter olabilir.");

            RuleFor(x => x.Description)
                .MaximumLength(500)
                .WithMessage("Açıklama alanı en fazla 500 karakter olabilir.");
        }
    }
}
