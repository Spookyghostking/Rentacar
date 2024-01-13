using Microsoft.EntityFrameworkCore;
using Rentacar.Data;
using Rentacar.DataModels;
using Rentacar.Services.Interfaces;

namespace Rentacar.Services
{
    public class DbCarService : ICarService
    {
        private readonly ApplicationDbContext _database;

        public DbCarService(ApplicationDbContext database)
        {
            _database = database;
        }

        public IEnumerable<CarDataModel> GetAll()
        {
            return _database.Cars
                .Include(c => c.CarModel)
                .Include(c => c.CarModel.Manufacturer)
                .Include(c => c.CarBodyType);
        }

        public CarDataModel GetById(int id)
        {
            return _database.Cars
                .Include(c => c.CarModel)
                .Include(c => c.CarModel.Manufacturer)
                .Include(c => c.CarBodyType)
                .FirstOrDefault(c => c.ID == id);
        }

        public CarDataModel Insert(CarDataModel car)
        {
            car.DateAdded = DateTime.Now;
            _database.Cars.Add(car);
            _database.SaveChanges();
            return car;
        }

        public CarDataModel Update(CarDataModel car)
        {
            _database.Cars.Update(car);
            _database.SaveChanges();
            return car;
        }

        public bool Delete(CarDataModel car)
        {
            _database.Remove(car);
            _database.SaveChanges();
            return true;
        }

        public IEnumerable<CarDataModel> GetAvailable(DateTime reservationBegin, DateTime reservationEnd)
        {
            List<CarDataModel> cars = new List<CarDataModel>();
            foreach (var car in _database.Cars
                .Include(c => c.Images)
                .Include(c => c.CarModel)
                .Include(c => c.CarModel.Manufacturer)
                .Include(c => c.CarBodyType)
                .ToList())
            {
                bool isReserved = _database.Reservations.Where(r => r.Car.ID == car.ID).Any(r => 
                    (reservationBegin >= r.ReservationBegin && r.ReservationEnd >= reservationBegin) ||
                    (reservationEnd >= r.ReservationBegin && r.ReservationEnd >= reservationEnd));
                Console.WriteLine("\n\n");
                Console.WriteLine(isReserved);
                Console.WriteLine("\n\n");
                if (!isReserved)
                    cars.Add(car);
            }
            return cars;
        }

        public IEnumerable<CarDataModel> GetAvailable(DateTime reservationBegin, DateTime reservationEnd, int carBodyTypeID)
        {
            List<CarDataModel> cars = new List<CarDataModel>();
            IQueryable<CarDataModel> carsQ = _database.Cars
                .Include(c => c.Images)
                .Include(c => c.CarModel)
                .Include(c => c.CarModel.Manufacturer)
                .Include(c => c.CarBodyType);
            carsQ = carsQ.Where(c => c.CarBodyType.ID == carBodyTypeID);
            foreach (var car in carsQ.ToList())
            {
                bool isReserved = _database.Reservations.Where(r => r.Car.ID == car.ID).Any(r =>
                    (reservationBegin >= r.ReservationBegin && r.ReservationEnd >= reservationBegin) ||
                    (reservationEnd >= r.ReservationBegin && r.ReservationEnd >= reservationEnd));
                //Console.WriteLine("\n\n");
                //Console.WriteLine(isReserved);
                //Console.WriteLine("\n\n");
                if (!isReserved)
                    cars.Add(car);
            }
            return cars;
        }
    }
}
