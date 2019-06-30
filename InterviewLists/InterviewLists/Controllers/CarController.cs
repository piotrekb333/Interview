using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InterviewLists.Application.Interfaces.Services;
using InterviewLists.Application.Models.Car;
using Microsoft.AspNetCore.Mvc;

namespace InterviewLists.Controllers
{
    public class CarController : Controller
    {
        private readonly ICarService _carService;
        private readonly ICarMakeService _makeCarService;
        private readonly ICarModelService _modelCarService;
        public CarController(ICarService carService, ICarMakeService makeCarService, ICarModelService modelCarService)
        {
            _carService = carService;
            _makeCarService = makeCarService;
            _modelCarService = modelCarService;
        }
        public IActionResult Index()
        {
            ViewData["CarMakes"] = _makeCarService.GetAll();
            return View();
        }

        public IActionResult GetAllTable()
        {
            var data = _carService.GetAll();
            return PartialView("Views/Shared/Car/_carTable.cshtml",data);
        }

        [HttpPost]
        public IActionResult Create([FromForm]CarCreate model)
        {
            _carService.Create(model);
            return Ok();
        }

        [HttpPut]
        public IActionResult Update(CarUpdate model)
        {
            _carService.Update(model);
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _carService.Delete(id);
            return Ok();
        }

        public IActionResult GetCarModels(int id)
        {
            var data = _modelCarService.GetByMakeId(id);
            return Json(data);
        }

        public IActionResult GetCarById(int id)
        {
            var data = _carService.GetById(id);
            return Json(data);
        }
        
    }
}