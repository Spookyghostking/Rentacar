using AutoMapper;
using Rentacar.BusinessLogic.Interfaces;
using Rentacar.BusinessModels.Car;
using Rentacar.BusinessModels.Reservation;
using Rentacar.DataModels;
using Rentacar.Services.Interfaces;

namespace Rentacar.BusinessLogic
{
    public class CarBusinessLogic : ICarBusinessLogic
    {
        private readonly IMapper _mapper;
        private readonly ICarService _cars;
        private readonly ICarModelService _carModels;
        private readonly ICarImageService _carImages;
        private readonly ICarBodyTypeService _carTypes;

        public CarBusinessLogic(
            IMapper mapper, 
            ICarService cars, 
            ICarModelService carModels,
            ICarImageService carImages,
            ICarBodyTypeService carTypes)
        {
            _mapper = mapper;
            _cars = cars;
            _carModels = carModels;
            _carImages = carImages;
            _carTypes = carTypes;
        }

        public IEnumerable<CarListBusinessModel> GetAll()
        {
            IEnumerable<CarDataModel> carDatas = _cars.GetAll();
            IEnumerable<CarListBusinessModel> cars = 
                _mapper.Map<IEnumerable<CarListBusinessModel>>(carDatas);
            return cars;
        }

        public CarDetailsBusinessModel GetCarDetails(int id)
        {
            CarDataModel car = _cars.GetById(id);
            car.Images = _carImages.GetByCarID(id).ToList();
            return _mapper.Map<CarDetailsBusinessModel>(car);
        }

        public CarEditBusinessModel GetCarEditModel(int id)
        {
            CarDataModel car = _cars.GetById(id);
            return _mapper.Map<CarEditBusinessModel>(car);
        }

        public CarDataModel Insert(CarCreateBusinessModel carBusiness)
        {
            CarDataModel carData = _mapper.Map<CarDataModel>(carBusiness);
            carData.CarModel = _carModels.GetById(carBusiness.CarModelID);
            carData.CarBodyType = _carTypes.GetById(carBusiness.CarBodyTypeID);
            carData = _cars.Insert(carData);
            return carData;
        }

        public CarDataModel Update(CarEditBusinessModel carBusiness)
        {
            CarDataModel carData = _mapper.Map<CarDataModel>(carBusiness);
            carData.CarModel = _carModels.GetById(carBusiness.CarModelID);
            _cars.Update(carData);
            return carData;
        }

        public bool DeleteByID(int id)
        {
            CarDataModel car = _cars.GetById(id);
            return _cars.Delete(car);
        }

        public IEnumerable<CarDetailsBusinessModel> GetAvailable(ReservationCreateBusinessModel reservation)
        {
            IEnumerable<CarDataModel> availableCars = _cars.GetAvailable(reservation.ReservationBegin, reservation.ReservationEnd);
            return _mapper.Map<IEnumerable<CarDetailsBusinessModel>>(availableCars);
        }

        public IEnumerable<CarDetailsBusinessModel> GetAvailable(ReservationEditBusinessModel reservation)
        {
            IEnumerable<CarDataModel> availableCars = _cars.GetAvailable(reservation.ReservationBegin, reservation.ReservationEnd);
            return _mapper.Map<IEnumerable<CarDetailsBusinessModel>>(availableCars);
        }
    }
}
