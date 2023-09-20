using Rentacar.BusinessModels.CarImage;
using Rentacar.DataModels;

namespace Rentacar.Services.Interfaces
{
    public interface ICarImageService
    {
        CarImageDataModel GetByID(int id);
        IEnumerable<CarImageDataModel> GetByCarID(int id);
        CarImageDataModel Insert(CarImageCreateBusinessModel image);
        CarImageDataModel Delete(CarImageDataModel image);
    }
}
