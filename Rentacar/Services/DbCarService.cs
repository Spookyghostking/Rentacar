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
            return _database.Cars.Include(c => c.CarModel).Include(c => c.CarModel.Manufacturer);
        }

        public CarDataModel GetById(int id)
        {
            return _database.Cars.Include(c => c.CarModel).Include(c => c.CarModel.Manufacturer).FirstOrDefault(c => c.ID == id);
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
    }
}
