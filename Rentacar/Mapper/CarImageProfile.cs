using AutoMapper;
using Rentacar.BusinessModels.CarImage;
using Rentacar.DataModels;

namespace Rentacar.Mapper
{
    public class CarImageProfile : Profile
    {
        public CarImageProfile()
        {
            CreateMap<CarImageDataModel, CarImageBusinessModel>();
        }
    }
}
