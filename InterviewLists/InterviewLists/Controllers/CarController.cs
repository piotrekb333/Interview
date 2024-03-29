﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using InterviewLists.Application.Interfaces.Services;
using InterviewLists.Application.Interfaces.WebServices;
using InterviewLists.Application.Models.Car;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InterviewLists.Controllers
{
    public class CarController : Controller
    {
        private readonly ICarService _carService;
        private readonly ICarMakeService _makeCarService;
        private readonly ICarModelService _modelCarService;
        private readonly ICountriesWebService _countriesWebService;
        public CarController(ICarService carService, ICarMakeService makeCarService, ICarModelService modelCarService, ICountriesWebService countriesWebService)
        {
            _carService = carService;
            _makeCarService = makeCarService;
            _modelCarService = modelCarService;
            _countriesWebService = countriesWebService;
        }
        public IActionResult Index()
        {
            ViewData["CarMakes"] = _makeCarService.GetAll();
            ViewData["Countries"] = _countriesWebService.GetCountries();
            return View();
        }

        public IActionResult GetAllTable()
        {
            var data = _carService.GetAll(User.Claims);
            return PartialView("Views/Shared/Car/_carTable.cshtml",data);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Create(CarCreate model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _carService.Create(model, User.FindFirst(ClaimTypes.NameIdentifier).Value);
            return Ok();
        }

        [HttpPut]
        [Authorize]
        public IActionResult Update(CarUpdate model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _carService.Update(model, User.Claims);
            return Ok();
        }

        [HttpDelete]
        [Authorize]
        public IActionResult Delete(int id)
        {
            _carService.Delete(id, User.Claims);
            return Ok();
        }

        public IActionResult GetCarModels(int id)
        {
            var data = _modelCarService.GetByMakeId(id);
            return Json(data);
        }

        [Authorize]
        public IActionResult GetCarById(int id)
        {
            var data = _carService.GetById(id, User.Claims);
            return Json(data);
        }
        
    }
}