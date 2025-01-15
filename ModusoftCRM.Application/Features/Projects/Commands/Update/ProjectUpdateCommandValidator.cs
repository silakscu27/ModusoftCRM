using FluentValidation;
using ModusoftCRM.Application.Features.Projects.Commands.Update;

namespace ModusoftCRM.Application.Features.Projects.Commands.Update
{
    public class ProjectUpdateCommandValidator : AbstractValidator<ProjectUpdateCommand>
    {
        public ProjectUpdateCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Proje kimliği boş olamaz.");

            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Proje adı boş olamaz.")
                .MaximumLength(100)
                .WithMessage("Proje adı 100 karakterden uzun olamaz.");

            RuleFor(x => x.Description)
                .MaximumLength(500)
                .WithMessage("Açıklama alanı 500 karakterden uzun olamaz.");
        }
    }
}
