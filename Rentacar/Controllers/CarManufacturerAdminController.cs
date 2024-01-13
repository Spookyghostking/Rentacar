using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rentacar.BusinessLogic.Interfaces;
using Rentacar.BusinessModels.CarManufacturer;
using Rentacar.DataModels;
using Rentacar.Services.Interfaces;

namespace Rentacar.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CarManufacturerAdminController : Controller
    {
        private readonly IMapper mapper;
        private readonly ICarManufacturerBusinessLogic _carManufacturers;

        public CarManufacturerAdminController(IMapper _mapper, ICarManufacturerBusinessLogic carManufacturers)
        {
            _mapper = _mapper;
            _carManufacturers = carManufacturers;
        }

        public IActionResult Index()
        {
            return View(_carManufacturers.GetAll());
        }

        public IActionResult Details(int id)
        {
            return View(_carManufacturers.GetByID(id));
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CarManufacturerCreateBusinessModel manufacturer)
        {
            _carManufacturers.Insert(manufacturer);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            CarManufacturerBusinessModel manufacturer = _carManufacturers.GetByID(id);
            return View(manufacturer);
        }
        [HttpPost]
        public IActionResult Edit(CarManufacturerBusinessModel manufacturer)
        {
            _carManufacturers.Update(manufacturer);
            return RedirectToAction("Details", new { id = manufacturer.ID });
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            CarManufacturerBusinessModel manufacturer = _carManufacturers.GetByID(id);
            return View(manufacturer);
        }
        [HttpPost]
        public IActionResult Delete(CarManufacturerBusinessModel manufacturer)
        {
            _carManufacturers.Delete(manufacturer);
            return RedirectToAction("Index");
        }
    }
}
