using AutoMapper;
using Rentacar.BusinessLogic.Interfaces;
using Rentacar.BusinessModels.CarModel;
using Rentacar.DataModels;
using Rentacar.Services.Interfaces;

namespace Rentacar.BusinessLogic
{
    public class CarModelBusinessLogic : ICarModelBusinessLogic
    {
        private readonly ICarModelService _carModels;
        private readonly ICarManufacturerService _carManufacturers;
        private readonly IMapper _mapper;

        public CarModelBusinessLogic(
            ICarModelService carModels,
            ICarManufacturerService carManufacturers,
            IMapper mapper)
        {
            _carModels = carModels;
            _carManufacturers = carManufacturers;
            _mapper = mapper;
        }

        public IEnumerable<CarModelListBusinessModel> GetAll()
        {
            IEnumerable<CarModelDataModel> models = _carModels.GetAll();
            return _mapper.Map<IEnumerable<CarModelListBusinessModel>>(models);
        }

        public CarModelListBusinessModel GetListModelByID(int id)
        {
            CarModelDataModel modelData = _carModels.GetById(id);
            return _mapper.Map<CarModelListBusinessModel>(modelData);
        }

        public CarModelEditBusinessModel GetEditModelByID(int id)
        {
            CarModelDataModel modelData = _carModels.GetById(id);
            return _mapper.Map<CarModelEditBusinessModel>(modelData);
        }

        public IEnumerable<CarModelListBusinessModel> GetByManufacturerID(int id)
        {
            IEnumerable<CarModelDataModel> models = _carModels.GetByManufacturerID(id);
            return _mapper.Map<IEnumerable<CarModelListBusinessModel>>(models);
        }

        public CarModelDataModel Insert(CarModelCreateBusinessModel model)
        {
            CarModelDataModel modelData = _mapper.Map<CarModelDataModel>(model);
            modelData.Manufacturer = _carManufacturers.GetById(modelData.Manufacturer.ID);
            _carModels.Insert(modelData);
            return modelData;
        }

        public CarModelEditBusinessModel Update(CarModelEditBusinessModel model)
        {
            CarModelDataModel modelData = _mapper.Map<CarModelDataModel>(model);
            modelData.Manufacturer = _carManufacturers.GetById(model.ManufacturerID);
            modelData = _carModels.Update(modelData);
            return _mapper.Map<CarModelEditBusinessModel>(modelData);
        }

        public bool Delete(CarModelListBusinessModel model)
        {
            CarModelDataModel modelData = _mapper.Map<CarModelDataModel>(model);
            return _carModels.Delete(modelData);
        }
    }
}
