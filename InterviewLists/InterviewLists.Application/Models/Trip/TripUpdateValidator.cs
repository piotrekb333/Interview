using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace InterviewLists.Application.Models.Trip
{
    public class TripUpdateValidator : AbstractValidator<TripUpdate>
    {
        public TripUpdateValidator()
        {
            RuleFor(x => x.Country).NotNull();
            RuleFor(x => x.DateEnd).NotNull();
            RuleFor(x => x.DateStart).NotNull();
            RuleFor(x => x.Price).NotNull();
        }
    }
}
