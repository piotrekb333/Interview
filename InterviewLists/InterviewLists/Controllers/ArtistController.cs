using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using InterviewLists.Application.Interfaces.Services;
using InterviewLists.Application.Interfaces.WebServices;
using InterviewLists.Application.Models.Artist;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InterviewLists.Controllers
{
    public class ArtistController : Controller
    {
        private readonly IArtistService _artistService;
        private readonly ICountriesWebService _countriesWebService;
        public ArtistController(IArtistService artistService, ICountriesWebService countriesWebService)
        {
            _artistService = artistService;
            _countriesWebService = countriesWebService;
        }
        public IActionResult Index()
        {
            ViewData["Countries"] = _countriesWebService.GetCountries();
            return View();
        }

        public IActionResult GetAllTable()
        {
            var data = _artistService.GetAll(User.Claims);
            return PartialView("Views/Shared/Artist/_artistTable.cshtml", data);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Create(ArtistCreate model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _artistService.Create(model, User.FindFirst(ClaimTypes.NameIdentifier).Value);
            return Ok();
        }

        [HttpPut]
        [Authorize]
        public IActionResult Update(ArtistUpdate model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _artistService.Update(model, User.Claims);
            return Ok();
        }

        [HttpDelete]
        [Authorize]
        public IActionResult Delete(int id)
        {
            _artistService.Delete(id, User.Claims);
            return Ok();
        }

        [Authorize]
        public IActionResult GetArtistById(int id)
        {
            var data = _artistService.GetById(id, User.Claims);
            return Json(data);
        }
    }
}