using AutoMapper;
using InterviewLists.Application.Exceptions;
using InterviewLists.Application.Interfaces;
using InterviewLists.Application.Interfaces.Services;
using InterviewLists.Application.Models.Artist;
using InterviewLists.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InterviewLists.Application.Implementations.Services
{
    public class ArtistService :  IArtistService
    {
        private readonly IInterviewDbContext _dbContext;
        private readonly IMapper _mapper;

        public ArtistService(IInterviewDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Create(ArtistCreate model)
        {
            var entity = new Artist
            {
                Birthday=model.Birthday,
                FirstName=model.FirstName,
                Country=model.Country,
                LastName=model.LastName
            };

            _dbContext.Artists.Add(entity);
            _dbContext.SaveChanges();
        }
        public void Update(ArtistUpdate model)
        {
            var entity = _dbContext.Artists.SingleOrDefault(m => m.Id == model.Id);
            if (entity == null)
            {
                throw new NotFoundException(nameof(Artist), model.Id);

            }

            entity.Birthday = model.Birthday;
            entity.Country = model.Country;
            entity.FirstName = model.FirstName;
            entity.LastName = model.LastName;
            _dbContext.Artists.Update(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = _dbContext.Artists.SingleOrDefault(m => m.Id == id);
            if (entity == null)
            {
                throw new NotFoundException(nameof(Artist), id);

            }
            _dbContext.Artists.Remove(entity);
            _dbContext.SaveChanges();
        }

        public ArtistDto GetById(int id)
        {
            var entity = _mapper.Map<ArtistDto>(_dbContext.Artists.SingleOrDefault(m => m.Id == id));
            return entity;
        }
        public IEnumerable<ArtistDto> Getall()
        {
            var entities = _mapper.Map<IEnumerable<ArtistDto>>(_dbContext.Artists);
            return entities;
        }
    }
}
