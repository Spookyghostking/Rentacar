using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Rentacar.BusinessLogic.Interfaces;
using Rentacar.BusinessModels.Car;
using Rentacar.BusinessModels.Reservation;

namespace Rentacar.Controllers
{
    public class ReservationController : Controller
    {
        private readonly ICarBusinessLogic _cars;
        private readonly IReservationBusinessLogic _reservations;
        private readonly IUserInfoBusinessLogic _userInfo;
        private readonly UserManager<IdentityUser> _userManager;

        public ReservationController(
            ICarBusinessLogic cars,
            IReservationBusinessLogic reservations,
            IUserInfoBusinessLogic userInfo,
            UserManager<IdentityUser> userManager)
        {
            _cars = cars;
            _reservations = reservations;
            _userInfo = userInfo;
            _userManager = userManager;
        }


        public IActionResult Info()
        {
            return View();
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            IdentityUser user = await _userManager.GetUserAsync(HttpContext.User);
            if (user == null)
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }
            List<ReservationDetailsBusinessModel> reservations = _reservations.GetbyUser(user.Id).ToList();
            return View(reservations);
        }

        public async Task<IActionResult> Details(int id)
        {
            IdentityUser requestUser = await _userManager.GetUserAsync(HttpContext.User);
            if (requestUser == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }

            ReservationDetailsBusinessModel reservation = _reservations.GetDetails(id);
            if (reservation == null)
                return StatusCode(StatusCodes.Status404NotFound);

            var userInfo = _userInfo.GetDetailsByID(reservation.UserInfoID);
            IdentityUser reservationUser = await _userManager.FindByIdAsync(userInfo.User.Id);

            if (requestUser != reservationUser)
            {
                return RedirectToPage("/Account/AccessDenied", new { area = "Identity" });
            }

            return View(reservation);
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
            ReservationDetailsBusinessModel reservationDetails = _reservations.Insert(reservation);
            return RedirectToAction("Details", new { id = reservationDetails.ID });
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ReservationEditBusinessModel reservation = _reservations.GetEdit(id);
            ViewBag.AvailableCars = _cars.GetAvailable(reservation);
            return View(reservation);
        }
        [HttpPost]
        public IActionResult Edit(ReservationEditBusinessModel reservation)
        {
            _reservations.Update(reservation);
            return RedirectToAction("Details", new { id = reservation.ID });
        }

        [HttpGet]
        [HttpPost]
        public IActionResult Delete(int id)
        {
            if (Request.Method.ToLower() == "post")
            {
                _reservations.DeleteByID(id);
                return RedirectToAction("Index", "Home");
            }
            ReservationDetailsBusinessModel reservation = _reservations.GetDetails(id);
            if (reservation == null)
                return StatusCode(StatusCodes.Status404NotFound);
            return View(reservation);
        }

        public IActionResult Confirm(int id)
        {
            if (_reservations.Confirm(id))
            {
                return RedirectToAction("Details", new {id = id});
            }
            return StatusCode(StatusCodes.Status418ImATeapot);
        }

        public IActionResult FindAvailableCars(ReservationCreateBusinessModel reservation)
        {
            //Console.WriteLine($"The start date is {reservation.ReservationBegin}");
            IEnumerable<CarDetailsBusinessModel> cars =  _cars.GetAvailable(reservation);
            return PartialView("_FindAvailableCars", cars);
            return Json("poop");
        }

        public IActionResult CarDetailsModal(int id)
        {
            CarDetailsBusinessModel car = _cars.GetCarDetails(id);
            return PartialView("_CarDetailsModal", car);
        }
    }
}
