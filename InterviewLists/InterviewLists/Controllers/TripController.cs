using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InterviewLists.Application.Interfaces.Services;
using InterviewLists.Application.Interfaces.WebServices;
using InterviewLists.Application.Models.Trip;
using Microsoft.AspNetCore.Mvc;

namespace InterviewLists.Controllers
{
    public class TripController : Controller
    {
        private readonly ITripService _tripService;
        private readonly ICountriesWebService _countriesWebService;
        public TripController(ITripService tripService, ICountriesWebService countriesWebService)
        {
            _tripService = tripService;
            _countriesWebService = countriesWebService;
        }
        public IActionResult Index()
        {
            ViewData["Countries"] = _countriesWebService.GetCountries();
            return View();
        }

        public IActionResult GetAllTable()
        {
            var data = _tripService.GetAll();
            return PartialView("Views/Shared/Trip/_tripTable.cshtml", data);
        }

        [HttpPost]
        public IActionResult Create(TripCreate model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _tripService.Create(model);
            return Ok();
        }

        [HttpPut]
        public IActionResult Update(TripUpdate model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _tripService.Update(model);
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _tripService.Delete(id);
            return Ok();
        }

        public IActionResult GetTripById(int id)
        {
            var data = _tripService.GetById(id);
            return Json(data);
        }
    }
}