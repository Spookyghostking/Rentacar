using Rentacar.DataModels;

namespace Rentacar.Services.Interfaces
{
    public interface ICarModelService
    {
        IEnumerable<CarModelDataModel> GetAll();
        IEnumerable<CarModelDataModel> GetByManufacturerID(int id);
        CarModelDataModel GetById(int id);
        CarModelDataModel Insert(CarModelDataModel model);
        CarModelDataModel Update(CarModelDataModel model);
        bool Delete(CarModelDataModel model);
    }
}
