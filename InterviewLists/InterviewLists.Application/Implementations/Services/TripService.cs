using AutoMapper;
using InterviewLists.Application.Exceptions;
using InterviewLists.Application.Interfaces;
using InterviewLists.Application.Interfaces.Services;
using InterviewLists.Application.Models.Trip;
using InterviewLists.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace InterviewLists.Application.Implementations.Services
{
    public class TripService : ITripService
    {
        private readonly IInterviewDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IAuthorizationService _authorizationService;

        public TripService(IInterviewDbContext dbContext, IMapper mapper, IAuthorizationService authorizationService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _authorizationService = authorizationService;
        }

        public void Create(TripCreate model, string userId)
        {
            var entity = new Trip
            {
                Price = model.Price,
                DateEnd = model.DateEnd,
                Country = model.Country,
                DateStart = model.DateStart,
                UserId = userId
            };

            _dbContext.Trips.Add(entity);
            _dbContext.SaveChanges();
        }
        public void Update(TripUpdate model, IEnumerable<Claim> claims)
        {
            var entity = _dbContext.Trips.SingleOrDefault(m => m.Id == model.Id);
            if (entity == null)
            {
                throw new NotFoundException(nameof(Trip), model.Id);
            }

            if (!_authorizationService.AllowModifyEntity(claims, entity.UserId))
                throw new NotAuthorizedException();

            entity.Price = model.Price;
            entity.Country = model.Country;
            entity.DateEnd = model.DateEnd;
            entity.DateStart = model.DateStart;
            _dbContext.Trips.Update(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(int id, IEnumerable<Claim> claims)
        {
            var entity = _dbContext.Trips.SingleOrDefault(m => m.Id == id);
            if (entity == null)
            {
                throw new NotFoundException(nameof(Trip), id);
            }

            if (!_authorizationService.AllowModifyEntity(claims, entity.UserId))
                throw new NotAuthorizedException();

            _dbContext.Trips.Remove(entity);
            _dbContext.SaveChanges();
        }

        public TripDto GetById(int id, IEnumerable<Claim> claims)
        {
            var entity = _mapper.Map<TripDto>(_dbContext.Trips.SingleOrDefault(m => m.Id == id));
            if (!_authorizationService.AllowModifyEntity(claims, entity.UserId))
                throw new NotAuthorizedException();
            return entity;
        }
        public IEnumerable<TripDto> GetAll(IEnumerable<Claim> claims)
        {
            var entities = _mapper.Map<IEnumerable<TripDto>>(_dbContext.Trips);
            entities = entities.Select(c => { c.AllowModifications = _authorizationService.AllowModifyEntity(claims, c.UserId); return c; }).ToList();

            return entities;
        }
    }
}
