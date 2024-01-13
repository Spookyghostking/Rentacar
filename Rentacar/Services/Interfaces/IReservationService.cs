using Rentacar.DataModels;

namespace Rentacar.Services.Interfaces
{
    public interface IReservationService
    {
        IEnumerable<ReservationDataModel> GetAll();
        ReservationDataModel GetById(int id);
        IEnumerable<ReservationDataModel> GetbyUser(string userID);
        ReservationDataModel Insert(ReservationDataModel reservation);
        ReservationDataModel Update(ReservationDataModel reservation);
        bool Delete(ReservationDataModel reservation);
    }
}
