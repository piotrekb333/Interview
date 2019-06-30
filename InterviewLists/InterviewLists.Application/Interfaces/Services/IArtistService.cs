using InterviewLists.Application.Models.Artist;
using InterviewLists.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace InterviewLists.Application.Interfaces.Services
{
    public interface IArtistService
    {
        void Create(ArtistCreate model);
        void Update(ArtistUpdate model);
        void Delete(int id);
        ArtistDto GetById(int id);
        IEnumerable<ArtistDto> GetAll();
    }
}
