using Microsoft.AspNetCore.Mvc;
using Rentacar.BusinessModels.Reservation;

namespace Rentacar.Controllers
{
    public class ReservationController : Controller
    {
        public IActionResult Info()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create(int id)
        {
            ReservationCreateBusinessModel reservation = new ReservationCreateBusinessModel();
            reservation.UserInfoID = id;
            return View(reservation);
        }
        [HttpPost]
        public IActionResult Create(ReservationCreateBusinessModel reservation)
        {
            throw new NotImplementedException();
        }

        public IActionResult FindAvailableCars(ReservationCreateBusinessModel reservation)
        {
            Console.WriteLine($"The start date is {reservation.ReservationBegin}");
            return Json("poop");
        }
    }
}
