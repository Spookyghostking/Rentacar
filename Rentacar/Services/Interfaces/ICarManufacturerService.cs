using Rentacar.DataModels;

namespace Rentacar.Services.Interfaces
{
    public interface ICarManufacturerService
    {
        IEnumerable<CarManufacturerDataModel> GetAll();
        CarManufacturerDataModel GetById(int id);
        CarManufacturerDataModel Insert(CarManufacturerDataModel manufacturer);
        CarManufacturerDataModel Update(CarManufacturerDataModel manufacturer);
        bool Delete(CarManufacturerDataModel manufacturer);
    }
}
