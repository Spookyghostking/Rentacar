using Rentacar.DataModels;

namespace Rentacar.Services.Interfaces
{
    public interface ICarBodyTypeService
    {
        IEnumerable<CarBodyTypeDataModel> GetAll();
        CarBodyTypeDataModel GetById(int id);
    }
}
