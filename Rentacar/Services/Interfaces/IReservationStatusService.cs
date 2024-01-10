using Rentacar.DataModels;

namespace Rentacar.Services.Interfaces
{
    public interface IReservationStatusService
    {
        //IEnumerable<ReservationStatusDataModel> GetAll();
        ReservationStatusDataModel GetByID(int id);
    }
}
