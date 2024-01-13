using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Rentacar.BusinessLogic.Interfaces;
using Rentacar.BusinessModels.Reservation;
using Rentacar.Services.Enums;

namespace Rentacar.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ReservationAdminController : Controller
    {
        private readonly IReservationBusinessLogic _reservations;

        public ReservationAdminController(IReservationBusinessLogic reservations)
        {
            _reservations = reservations;
        }

        public IActionResult Index()
        {
            IEnumerable<ReservationDetailsBusinessModel> reservations = _reservations.GetAll();
            return View(reservations);
        }

        public IActionResult Details(int id)
        {
            ReservationDetailsBusinessModel reservation = _reservations.GetDetails(id);
            return View(reservation);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ReservationEditAdminBusinessModel reservation = _reservations.GetEditAdmin(id);

            reservation.StatusOptions = new List<SelectListItem>();

            var status = ReservationStatuses.Cart;
            reservation.StatusOptions.Add(new SelectListItem(status.ToString(), ((int)status).ToString()));
            status = ReservationStatuses.Reserved;
            reservation.StatusOptions.Add(new SelectListItem(status.ToString(), ((int)status).ToString()));
            status = ReservationStatuses.Active;
            reservation.StatusOptions.Add(new SelectListItem(status.ToString(), ((int)status).ToString()));
            status = ReservationStatuses.Archived;
            reservation.StatusOptions.Add(new SelectListItem(status.ToString(), ((int)status).ToString()));
            status = ReservationStatuses.Remove;
            reservation.StatusOptions.Add(new SelectListItem(status.ToString(), ((int)status).ToString()));

            return View(reservation);
        }
        [HttpPost]
        public IActionResult Edit(ReservationEditAdminBusinessModel reservation)
        {
            ReservationDetailsBusinessModel details = _reservations.Update(reservation);
            return RedirectToAction("Details", new { id = details.ID });
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            ReservationDetailsBusinessModel reservation = _reservations.GetDetails(id);
            return View(reservation);
        }
        [HttpPost]
        public IActionResult Delete(ReservationDetailsBusinessModel reservation)
        {
            _reservations.DeleteByID(reservation.ID);
            return RedirectToAction("Index");
        }
    }
}
