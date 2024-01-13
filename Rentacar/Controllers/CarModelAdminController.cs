using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rentacar.BusinessLogic.Interfaces;
using Rentacar.BusinessModels.CarModel;
using Rentacar.DataModels;
using Rentacar.Services.Interfaces;

namespace Rentacar.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CarModelAdminController : Controller
    {
        private readonly ICarModelBusinessLogic _carModels;
        private readonly ICarManufacturerBusinessLogic _carManufacturers;

        public CarModelAdminController(
            ICarModelBusinessLogic carModels,
            ICarManufacturerBusinessLogic carManufacturers)
        {
            _carModels = carModels;
            _carManufacturers = carManufacturers;
        }

        public IActionResult Index()
        {
            IEnumerable<CarModelListBusinessModel> models = _carModels.GetAll()
                .OrderBy(m => m.Name)
                .OrderBy(m => m.ManufacturerName);
            return View(models);
        }
        public IActionResult Details(int id)
        {
            return View(_carModels.GetListModelByID(id));
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.ManufacturerOptions = _carManufacturers.GetAll();
            return View();
        }
        [HttpPost]
        public IActionResult Create(CarModelCreateBusinessModel model)
        {
            CarModelDataModel modelData = _carModels.Insert(model);
            return RedirectToAction("Details", new { id = modelData.ID });
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.ManufacturerOptions = _carManufacturers.GetAll();
            CarModelEditBusinessModel model = _carModels.GetEditModelByID(id);
            return View(model);
        }
        [HttpPost]
        public IActionResult Edit(CarModelEditBusinessModel model)
        {
            _carModels.Update(model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            return View(_carModels.GetListModelByID(id));
        }
        [HttpPost]
        public IActionResult Delete(CarModelListBusinessModel model)
        {
            _carModels.Delete(model);
            return RedirectToAction("Index");
        }

        public JsonResult GetManufacturerModels(int id)
        {
            return Json(_carModels.GetByManufacturerID(id));
        }
    }
}
