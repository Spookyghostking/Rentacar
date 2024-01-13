using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rentacar.BusinessLogic.Interfaces;
using Rentacar.BusinessModels.CarImage;
using Rentacar.Services.Interfaces;

namespace Rentacar.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CarImageAdminController : Controller
    {
        private readonly ICarImageBusinessLogic _images;

        public CarImageAdminController(ICarImageBusinessLogic images)
        {
            _images = images;
        }

        [HttpGet]
        public IActionResult Create(int id)
        {
            CarImagesCreateBusinessModel images = new CarImagesCreateBusinessModel() { CarID = id };
            return View(images);
        }
        [HttpPost]
        public IActionResult Create(CarImagesCreateBusinessModel imageModel)
        {
            _images.Insert(imageModel);
            return RedirectToAction("CarImages", "CarAdmin", new { id = imageModel.CarID });
        }

        [HttpGet]
        [HttpPost]
        public IActionResult Delete(int id)
        {
            CarImageBusinessModel image = _images.GetByID(id);
            if (Request.Method == "POST")
            {
                _images.DeleteByID(id);
                return RedirectToAction("CarImages", "CarAdmin", new { ID = image.CarID });
            }
            return View(image);
        }
    }
}
