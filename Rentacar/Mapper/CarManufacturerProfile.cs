using AutoMapper;
using Rentacar.BusinessModels.CarManufacturer;
using Rentacar.DataModels;

namespace Rentacar.Mapper
{
    public class CarManufacturerProfile : Profile
    {
        public CarManufacturerProfile()
        {
            CreateMap<CarManufacturerDataModel, CarManufacturerBusinessModel>();
            CreateMap<CarManufacturerBusinessModel, CarManufacturerDataModel>();
            // I approve of this
            CreateMap<CarManufacturerCreateBusinessModel, CarManufacturerDataModel>();
        }
    }
}
