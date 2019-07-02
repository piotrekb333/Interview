using AutoMapper;
using InterviewLists.Application.Exceptions;
using InterviewLists.Application.Interfaces;
using InterviewLists.Application.Interfaces.Services;
using InterviewLists.Application.Models.Artist;
using InterviewLists.Application.Roles;
using InterviewLists.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace InterviewLists.Application.Implementations.Services
{
    public class ArtistService :  IArtistService
    {
        private readonly IInterviewDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IAuthorizationService _authorizationService;

        public ArtistService(IInterviewDbContext dbContext, IMapper mapper, IAuthorizationService authorizationService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _authorizationService = authorizationService;
        }

        public void Create(ArtistCreate model,string userId)
        {
            var entity = new Artist
            {
                Birthday=model.Birthday,
                FirstName=model.FirstName,
                Country=model.Country,
                LastName=model.LastName,
                UserId= userId
            };

            _dbContext.Artists.Add(entity);
            _dbContext.SaveChanges();
        }
        public void Update(ArtistUpdate model, IEnumerable<Claim> claims)
        {
            var entity = _dbContext.Artists.SingleOrDefault(m => m.Id == model.Id);
            if (entity == null)
            {
                throw new NotFoundException(nameof(Artist), model.Id);
            }

            if(!_authorizationService.AllowModifyEntity(claims,entity.UserId))
                throw new NotAuthorizedException();

            entity.Birthday = model.Birthday;
            entity.Country = model.Country;
            entity.FirstName = model.FirstName;
            entity.LastName = model.LastName;
            _dbContext.Artists.Update(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(int id, IEnumerable<Claim> claims)
        {
            var entity = _dbContext.Artists.SingleOrDefault(m => m.Id == id);
            if (entity == null)
            {
                throw new NotFoundException(nameof(Artist), id);
            }

            if (!_authorizationService.AllowModifyEntity(claims, entity.UserId))
                throw new NotAuthorizedException();

            _dbContext.Artists.Remove(entity);
            _dbContext.SaveChanges();
        }

        public ArtistDto GetById(int id, IEnumerable<Claim> claims)
        {
            var entity = _mapper.Map<ArtistDto>(_dbContext.Artists.SingleOrDefault(m => m.Id == id));
            if (!_authorizationService.AllowModifyEntity(claims, entity.UserId))
                throw new NotAuthorizedException();
            return entity;
        }
        public IEnumerable<ArtistDto> GetAll(IEnumerable<Claim> claims)
        {
            var entities = _mapper.Map<IEnumerable<ArtistDto>>(_dbContext.Artists);
            entities = entities.Select(c => { c.AllowModifications = _authorizationService.AllowModifyEntity(claims,c.UserId); return c; }).ToList();
            return entities;
        }
    }
}
