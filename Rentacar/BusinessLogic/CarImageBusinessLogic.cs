using AutoMapper;
using Rentacar.BusinessLogic.Interfaces;
using Rentacar.BusinessModels.CarImage;
using Rentacar.DataModels;
using Rentacar.Services.Interfaces;

namespace Rentacar.BusinessLogic
{
    public class CarImageBusinessLogic : ICarImageBusinessLogic
    {
        private readonly IMapper _mapper;
        private readonly ICarImageService _images;

        public CarImageBusinessLogic(
            IMapper mapper, 
            ICarImageService images)
        {
            _mapper = mapper;
            _images = images;
        }

        public CarImageBusinessModel GetByID(int id)
        {
            CarImageDataModel image = _images.GetByID(id);
            return _mapper.Map<CarImageBusinessModel>(image);
        }

        public IEnumerable<CarImageBusinessModel> GetByCarID(int id)
        {
            IEnumerable<CarImageDataModel> images = _images.GetByCarID(id);
            return _mapper.Map<IEnumerable<CarImageBusinessModel>>(images);
        }

        public void Insert(CarImagesCreateBusinessModel imageModel)
        {
            if (imageModel.Images == null ||  imageModel.Images.Count == 0)
                return;
            foreach (var image in imageModel.Images)
            {
                CarImageCreateBusinessModel imageData = new CarImageCreateBusinessModel();
                imageData.Image = image;
                imageData.CarID = imageModel.CarID;
                _images.Insert(imageData);
            }
        }

        public CarImageBusinessModel DeleteByID(int id)
        {
            CarImageDataModel image = _images.GetByID(id);
            _images.Delete(image);
            return _mapper.Map<CarImageBusinessModel>(image);
        }
    }
}
