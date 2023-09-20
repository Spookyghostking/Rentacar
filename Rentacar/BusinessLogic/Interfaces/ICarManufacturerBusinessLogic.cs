using Rentacar.BusinessModels.CarManufacturer;

namespace Rentacar.BusinessLogic.Interfaces
{
    public interface ICarManufacturerBusinessLogic
    {
        IEnumerable<CarManufacturerBusinessModel> GetAll();
        CarManufacturerBusinessModel GetByID(int id);
        CarManufacturerBusinessModel Insert(CarManufacturerBusinessModel manufacturer);
        CarManufacturerBusinessModel Update(CarManufacturerBusinessModel manufacturer);
        bool Delete(CarManufacturerBusinessModel manufacturer);
    }
}
