using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace InterviewLists.Application.Models.Car
{
    public class CarUpdateValidator : AbstractValidator<CarUpdate>
    {
        public CarUpdateValidator()
        {
            RuleFor(x => x.CarMakeId).NotNull();
            RuleFor(x => x.CarModelId).NotNull();
            RuleFor(x => x.Country).NotNull();
            RuleFor(x => x.DateOfProduction).NotNull();
            RuleFor(x => x.Price).NotNull();
        }
    }
}
