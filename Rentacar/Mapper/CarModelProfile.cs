using AutoMapper;
using Rentacar.BusinessModels.CarModel;
using Rentacar.DataModels;
using Rentacar.Services.Interfaces;

namespace Rentacar.Mapper
{
    public class CarModelProfile : Profile
    {

        public CarModelProfile()
        {
            CreateMap<CarModelCreateBusinessModel, CarModelDataModel>()
                .ForMember(md => md.Manufacturer, options =>
                {
                    options.MapFrom(mc => new CarManufacturerDataModel() { ID = mc.ManufacturerID });
                });

            CreateMap<CarModelDataModel, CarModelListBusinessModel>();
            CreateMap<CarModelListBusinessModel, CarModelDataModel>();

            CreateMap<CarModelEditBusinessModel, CarModelDataModel>();
            CreateMap<CarModelDataModel, CarModelEditBusinessModel>();
        }
    }
}
