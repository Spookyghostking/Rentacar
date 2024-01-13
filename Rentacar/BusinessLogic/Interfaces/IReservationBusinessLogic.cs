using Rentacar.BusinessModels.Reservation;

namespace Rentacar.BusinessLogic.Interfaces
{
    public interface IReservationBusinessLogic
    {
        IEnumerable<ReservationDetailsBusinessModel> GetAll();
        ReservationDetailsBusinessModel GetDetails(int id);
        ReservationEditBusinessModel GetEdit(int id);
        ReservationEditAdminBusinessModel GetEditAdmin(int id);
        IEnumerable<ReservationDetailsBusinessModel> GetbyUser(string userID);
        ReservationDetailsBusinessModel Insert(ReservationCreateBusinessModel reservation);
        ReservationDetailsBusinessModel Update(ReservationEditBusinessModel reservation);
        ReservationDetailsBusinessModel Update(ReservationEditAdminBusinessModel reservation);
        bool Confirm(int id);
        bool DeleteByID(int id);
    }
}
