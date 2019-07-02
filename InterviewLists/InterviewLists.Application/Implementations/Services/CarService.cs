using AutoMapper;
using InterviewLists.Application.Exceptions;
using InterviewLists.Application.Interfaces;
using InterviewLists.Application.Interfaces.Services;
using InterviewLists.Application.Models.Car;
using InterviewLists.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace InterviewLists.Application.Implementations.Services
{
    public class CarService : ICarService
    {
        private readonly IInterviewDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IAuthorizationService _authorizationService;

        public CarService(IInterviewDbContext dbContext, IMapper mapper, IAuthorizationService authorizationService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _authorizationService = authorizationService;
        }

        public void Create(CarCreate model, string userId)
        {
            var entity = new Car
            {
                CarMakeId=model.CarMakeId,
                CarModelId=model.CarModelId,
                DateOfProduction=model.DateOfProduction,
                Price=model.Price,
                Country = model.Country,
                UserId = userId
            };

            _dbContext.Cars.Add(entity);
            _dbContext.SaveChanges();
        }
        public void Update(CarUpdate model, IEnumerable<Claim> claims)
        {
            var entity = _dbContext.Cars.SingleOrDefault(m => m.Id == model.Id);
            if (entity == null)
            {
                throw new NotFoundException(nameof(Car), model.Id);
            }

            if (!_authorizationService.AllowModifyEntity(claims, entity.UserId))
                throw new NotAuthorizedException();

            entity.CarMakeId = model.CarMakeId;
            entity.Country = model.Country;
            entity.CarModelId = model.CarModelId;
            entity.Price = model.Price;
            entity.DateOfProduction = model.DateOfProduction;

            _dbContext.Cars.Update(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(int id, IEnumerable<Claim> claims)
        {
            var entity = _dbContext.Cars.SingleOrDefault(m => m.Id == id);
            if (entity == null)
            {
                throw new NotFoundException(nameof(Artist), id);
            }

            if (!_authorizationService.AllowModifyEntity(claims, entity.UserId))
                throw new NotAuthorizedException();

            _dbContext.Cars.Remove(entity);
            _dbContext.SaveChanges();
        }

        public CarDto GetById(int id, IEnumerable<Claim> claims)
        {
            var entity = _mapper.Map<CarDto>(_dbContext.Cars.SingleOrDefault(m => m.Id == id));

            if (!_authorizationService.AllowModifyEntity(claims, entity.UserId))
                throw new NotAuthorizedException();

            return entity;
        }
        public IEnumerable<CarDto> GetAll(IEnumerable<Claim> claims)
        {
            var entities = _mapper.Map<IEnumerable<CarDto>>(_dbContext.Cars.Include(m=>m.CarMake).Include(m=>m.CarModel).AsNoTracking());
            entities = entities.Select(c => { c.AllowModifications = _authorizationService.AllowModifyEntity(claims, c.UserId); return c; }).ToList();

            return entities;
        }
    }
}
