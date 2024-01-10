using Rentacar.BusinessModels.Reservation;

namespace Rentacar.BusinessLogic.Interfaces
{
    public interface IReservationBusinessLogic
    {
        IEnumerable<ReservationDetailsBusinessModel> GetAll();
        ReservationDetailsBusinessModel GetDetails(int id);
        ReservationEditBusinessModel GetEdit(int id);
        ReservationDetailsBusinessModel Insert(ReservationCreateBusinessModel reservation);
        ReservationDetailsBusinessModel Update(ReservationEditBusinessModel reservation);
        bool Confirm(int id);
        bool DeleteByID(int id);
    }
}
