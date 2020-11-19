using System;
using System.Collections.Generic;
using System.Text;
using AnimalSpawn.Domain.DTOs;
using FluentValidation;

namespace AnimalSpawn.Infrastructure.Validators
{
    public class AnimalValidator : AbstractValidator<AnimalRequestDto>
    {
        public AnimalValidator()
        {
            RuleFor(animal => animal.Name)
                .NotNull()
                .NotEmpty()
                .Length(3, 50);
            RuleFor(animal => animal.CaptureDate)
                .LessThan(DateTime.Now);
            RuleFor(animal => animal.CaptureCondition)
                .NotNull()
                .NotEmpty()
                .Length(4, 200);
        }
    }
}
