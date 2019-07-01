using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InterviewLists.Application.Interfaces.Services;
using InterviewLists.Application.Interfaces.WebServices;
using InterviewLists.Application.Models.Artist;
using Microsoft.AspNetCore.Mvc;

namespace InterviewLists.Controllers
{
    public class ArtistController : Controller
    {
        private readonly IArtistService _tripService;
        private readonly ICountriesWebService _countriesWebService;
        public ArtistController(IArtistService tripService, ICountriesWebService countriesWebService)
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
            return PartialView("Views/Shared/Artist/_artistTable.cshtml", data);
        }

        [HttpPost]
        public IActionResult Create([FromForm]ArtistCreate model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _tripService.Create(model);
            return Ok();
        }

        [HttpPut]
        public IActionResult Update(ArtistUpdate model)
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

        public IActionResult GetArtistById(int id)
        {
            var data = _tripService.GetById(id);
            return Json(data);
        }
    }
}