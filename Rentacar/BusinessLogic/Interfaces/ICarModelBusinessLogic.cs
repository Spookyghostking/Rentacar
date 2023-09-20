using Rentacar.BusinessModels.CarModel;
using Rentacar.DataModels;

namespace Rentacar.BusinessLogic.Interfaces
{
    public interface ICarModelBusinessLogic
    {
        IEnumerable<CarModelListBusinessModel> GetAll();
        CarModelListBusinessModel GetListModelByID(int id);
        CarModelEditBusinessModel GetEditModelByID(int id);
        IEnumerable<CarModelListBusinessModel> GetByManufacturerID(int id);
        CarModelDataModel Insert(CarModelCreateBusinessModel model);
        CarModelEditBusinessModel Update(CarModelEditBusinessModel model);
        bool Delete(CarModelListBusinessModel model);
    }
}
