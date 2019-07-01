using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace InterviewLists.Application.Models.Artist
{
    public class ArtistCreateValidator : AbstractValidator<ArtistCreate>
    {
        public ArtistCreateValidator()
        {
            RuleFor(x => x.Birthday).NotNull();
            RuleFor(x => x.Country).NotNull();
            RuleFor(x => x.FirstName).NotNull();
            RuleFor(x => x.LastName).NotNull();
        }
    }
}
