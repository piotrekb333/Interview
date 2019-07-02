using InterviewLists.Application.Models.Artist;
using InterviewLists.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace InterviewLists.Application.Interfaces.Services
{
    public interface IArtistService
    {
        void Create(ArtistCreate model, string userId);
        void Update(ArtistUpdate model, IEnumerable<Claim> claims);
        void Delete(int id, IEnumerable<Claim> claims);
        ArtistDto GetById(int id, IEnumerable<Claim> claims);
        IEnumerable<ArtistDto> GetAll(IEnumerable<Claim> claims);
    }
}
