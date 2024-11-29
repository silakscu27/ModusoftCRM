using FluentValidation;

namespace ModusoftCRM.Application.Features.CompanyDetails.Queries.GetById
{
    public class CompanyDetailGetByIdQueryValidator : AbstractValidator<CompanyDetailGetByIdQuery>
    {
        public CompanyDetailGetByIdQueryValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0.")
                .NotEmpty().WithMessage("Id cannot be empty.");
        }
    }
}
