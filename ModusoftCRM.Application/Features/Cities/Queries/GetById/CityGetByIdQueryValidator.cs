using FluentValidation;

namespace ModusoftCRM.Application.Features.Cities.Queries.GetById
{
    public class CityGetByIdQueryValidator : AbstractValidator<CityGetByIdQuery>
    {
        public CityGetByIdQueryValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("0'dan büyük olmalı.")
                .NotEmpty().WithMessage("Id alanı boş olamaz.");
        }
    }
}
