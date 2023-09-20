using AutoMapper;
using Rentacar.BusinessLogic.Interfaces;
using Rentacar.BusinessModels.CarManufacturer;
using Rentacar.DataModels;
using Rentacar.Services.Interfaces;

namespace Rentacar.BusinessLogic
{
    public class CarManufacturerBusinessLogic : ICarManufacturerBusinessLogic
    {
        private readonly IMapper _mapper;
        private readonly ICarManufacturerService _carManufacturers;

        public CarManufacturerBusinessLogic(IMapper mapper, ICarManufacturerService carManufacturers)
        {
            _mapper = mapper;
            _carManufacturers = carManufacturers;
        }
        public IEnumerable<CarManufacturerBusinessModel> GetAll()
        {
            IEnumerable<CarManufacturerDataModel> manufacturers = _carManufacturers.GetAll();
            return _mapper.Map<IEnumerable<CarManufacturerBusinessModel>>(manufacturers);
        }

        public CarManufacturerBusinessModel GetByID(int id)
        {
            CarManufacturerDataModel manufacturer = _carManufacturers.GetById(id);
            return _mapper.Map<CarManufacturerBusinessModel>(manufacturer);
        }

        public CarManufacturerBusinessModel Insert(CarManufacturerBusinessModel manufacturer)
        {
            CarManufacturerDataModel manufacturerData = _mapper.Map<CarManufacturerDataModel>(manufacturer);
            manufacturerData = _carManufacturers.Insert(manufacturerData);
            return _mapper.Map<CarManufacturerBusinessModel>(manufacturerData);
        }

        public CarManufacturerBusinessModel Update(CarManufacturerBusinessModel manufacturer)
        {
            CarManufacturerDataModel manufacturerData = _mapper.Map<CarManufacturerDataModel>(manufacturer);
            manufacturerData = _carManufacturers.Update(manufacturerData);
            return _mapper.Map<CarManufacturerBusinessModel>(manufacturerData);
        }
        public bool Delete(CarManufacturerBusinessModel manufacturer)
        {
            CarManufacturerDataModel manufacturerData = _mapper.Map<CarManufacturerDataModel>(manufacturer);
            return _carManufacturers.Delete(manufacturerData);
        }

    }
}
