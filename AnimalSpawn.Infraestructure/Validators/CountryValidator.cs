using AnimalSpawn.Domain.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalSpawn.Infrastructure.Validators
{
    public class CountryValidator : AbstractValidator<CountryRequestDto>
    {
        public CountryValidator()
        {
            RuleFor(country => country.Name)
                .NotNull()
                .NotEmpty()
                .Length(4, 50);
        }
    }
}
