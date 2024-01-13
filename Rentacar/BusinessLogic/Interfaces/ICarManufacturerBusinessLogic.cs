using Rentacar.BusinessModels.CarManufacturer;

namespace Rentacar.BusinessLogic.Interfaces
{
    public interface ICarManufacturerBusinessLogic
    {
        IEnumerable<CarManufacturerBusinessModel> GetAll();
        CarManufacturerBusinessModel GetByID(int id);
        CarManufacturerBusinessModel Insert(CarManufacturerCreateBusinessModel manufacturer);
        CarManufacturerBusinessModel Update(CarManufacturerBusinessModel manufacturer);
        bool Delete(CarManufacturerBusinessModel manufacturer);
    }
}
