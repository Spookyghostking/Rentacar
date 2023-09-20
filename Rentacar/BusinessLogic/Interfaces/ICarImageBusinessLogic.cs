using Rentacar.BusinessModels.CarImage;

namespace Rentacar.BusinessLogic.Interfaces
{
    public interface ICarImageBusinessLogic
    {
        CarImageBusinessModel GetByID(int id);
        IEnumerable<CarImageBusinessModel> GetByCarID(int id);
        void Insert(CarImagesCreateBusinessModel imageModel);
        CarImageBusinessModel DeleteByID(int id);
    }
}
