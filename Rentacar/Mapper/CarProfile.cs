using AutoMapper;
using Rentacar.DataModels;
using Rentacar.BusinessModels.Car;

namespace Rentacar.Mapper
{
    public class CarProfile : Profile
    {
        public CarProfile()
        {
            CreateMap<CarDataModel, CarBusinessModel>();

            CreateMap<CarDataModel, CarCreateBusinessModel>();
            CreateMap<CarCreateBusinessModel, CarDataModel>();

            CreateMap<CarDataModel, CarListBusinessModel>()
                .ForMember(
                    car => car.CarManufacturerName, 
                    action => action.MapFrom(carData => carData.CarModel.Manufacturer.Name));

            CreateMap<CarDataModel, CarDetailsBusinessModel>()
                .ForMember(
                    car => car.CarManufacturerName,
                    action => action.MapFrom(carData => carData.CarModel.Manufacturer.Name));

            CreateMap<CarDataModel, CarEditBusinessModel>()
                .ForMember(
                    car => car.CarManufacturer,
                    action => action.MapFrom(carData => carData.CarModel.Manufacturer));
            CreateMap<CarEditBusinessModel, CarDataModel>();
        }
    }
}
