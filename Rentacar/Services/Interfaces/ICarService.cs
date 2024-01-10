using Rentacar.DataModels;

namespace Rentacar.Services.Interfaces
{
    public interface ICarService
    {
        IEnumerable<CarDataModel> GetAll();
        CarDataModel GetById(int id);
        CarDataModel Insert(CarDataModel car);
        CarDataModel Update(CarDataModel car);
        bool Delete(CarDataModel car);
        IEnumerable<CarDataModel> GetAvailable(DateTime reservationBegin, DateTime reservationEnd);
    }
}
