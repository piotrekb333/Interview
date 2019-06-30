using AutoMapper;
using InterviewLists.Application.Exceptions;
using InterviewLists.Application.Interfaces;
using InterviewLists.Application.Interfaces.Services;
using InterviewLists.Application.Models.Trip;
using InterviewLists.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InterviewLists.Application.Implementations.Services
{
    public class TripService : ITripService
    {
        private readonly IInterviewDbContext _dbContext;
        private readonly IMapper _mapper;

        public TripService(IInterviewDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Create(TripCreate model)
        {
            var entity = new Trip
            {
                Price = model.Price,
                DateEnd = model.DateEnd,
                Country = model.Country,
                DateStart = model.DateStart
            };

            _dbContext.Trips.Add(entity);
            _dbContext.SaveChanges();
        }
        public void Update(TripUpdate model)
        {
            var entity = _dbContext.Trips.SingleOrDefault(m => m.Id == model.Id);
            if (entity == null)
            {
                throw new NotFoundException(nameof(Trip), model.Id);

            }

            entity.Price = model.Price;
            entity.Country = model.Country;
            entity.DateEnd = model.DateEnd;
            entity.DateStart = model.DateStart;
            _dbContext.Trips.Update(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = _dbContext.Trips.SingleOrDefault(m => m.Id == id);
            if (entity == null)
            {
                throw new NotFoundException(nameof(Trip), id);

            }
            _dbContext.Trips.Remove(entity);
            _dbContext.SaveChanges();
        }

        public TripDto GetById(int id)
        {
            var entity = _mapper.Map<TripDto>(_dbContext.Trips.SingleOrDefault(m => m.Id == id));
            return entity;
        }
        public IEnumerable<TripDto> Getall()
        {
            var entities = _mapper.Map<IEnumerable<TripDto>>(_dbContext.Trips);
            return entities;
        }
    }
}
