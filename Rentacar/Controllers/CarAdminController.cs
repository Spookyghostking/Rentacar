using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rentacar.BusinessLogic.Interfaces;
using Rentacar.BusinessModels.Car;
using Rentacar.BusinessModels.CarImage;
using Rentacar.DataModels;
using Rentacar.Services.Interfaces;

namespace Rentacar.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CarAdminController : Controller
    {
        private readonly ICarBusinessLogic _cars;
        private readonly ICarManufacturerService _carManufacturers;
        private readonly ICarModelService _carModels;
        private readonly ICarImageBusinessLogic _carImages;
        private readonly ICarBodyTypeBusinessLogic _carTypes;

        public CarAdminController(
            ICarBusinessLogic cars, 
            ICarManufacturerService carManufacturers, 
            ICarModelService carModels, 
            ICarImageBusinessLogic carImages,
            ICarBodyTypeBusinessLogic carTypes)
        {
            _cars = cars;
            _carManufacturers = carManufacturers;
            _carModels = carModels;
            _carImages = carImages;
            _carTypes = carTypes;
        }

        public IActionResult Index()
        {
            return View(_cars.GetAll());
        }

        public IActionResult Details(int id)
        {
            return View(_cars.GetCarDetails(id));
            throw new NotImplementedException();
            //return View(_cars.GetById(id));
        }

        [Authorize]
        [HttpGet]
        public IActionResult Create()
        {
            CarCreateBusinessModel car = new CarCreateBusinessModel();
            car.CarBodyTypeList = _carTypes.GetSelectListItems();
            ViewBag.CarManufacturerOptions = _carManufacturers.GetAll();
            return View(car);
        }
        [Authorize]
        [HttpPost]
        public IActionResult Create(CarCreateBusinessModel car)
        {
            CarDataModel carData = _cars.Insert(car);
            if (carData != null)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [Authorize]
        [HttpGet]
        public IActionResult Edit(int id)
        {
            CarEditBusinessModel car = _cars.GetCarEditModel(id);
            ViewBag.CarManufacturerOptions = _carManufacturers.GetAll();
            ViewBag.CarModelOptions = _carModels.GetByManufacturerID(car.CarManufacturer.ID);
            car.CarBodyTypeList = _carTypes.GetSelectListItems();
            return View(car);
        }
        [Authorize]
        [HttpPost]
        public IActionResult Edit(CarEditBusinessModel car)
        {
            _cars.Update(car);
            return RedirectToAction("Index");
        }

        [Authorize]
        [HttpGet]
        [HttpPost]
        public IActionResult Delete(int id)
        {
            if (Request.Method == "POST")
            {
                _cars.DeleteByID(id);
                return RedirectToAction("Index");
            }
            return View(_cars.GetCarDetails(id));
        }

        [HttpGet]
        public IActionResult CarImages(int id)
        {
            IEnumerable<CarImageBusinessModel> images = _carImages.GetByCarID(id);
            if (images == null || images.Count() == 0) 
                return RedirectToAction("Details", new { id });
            return View(images);
        }
    }
}
