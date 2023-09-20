using Rentacar.Data;
using Rentacar.DataModels;
using Rentacar.Services.Interfaces;

namespace Rentacar.Services
{
    public class DbCarManufacturerService : ICarManufacturerService
    {
        private readonly ApplicationDbContext _database;

        public DbCarManufacturerService(ApplicationDbContext database)
        {
            _database = database;
        }

        public IEnumerable<CarManufacturerDataModel> GetAll()
        {
            return _database.CarManufacturers;
        }

        public CarManufacturerDataModel GetById(int id)
        {
            return _database.CarManufacturers.FirstOrDefault(m => m.ID == id);
        }

        public CarManufacturerDataModel Insert(CarManufacturerDataModel manufacturer)
        {
            _database.CarManufacturers.Add(manufacturer);
            _database.SaveChanges();
            return manufacturer;
        }

        public CarManufacturerDataModel Update(CarManufacturerDataModel manufacturer)
        {
            _database.CarManufacturers.Update(manufacturer);
            _database.SaveChanges();
            return manufacturer;
        }

        public bool Delete(CarManufacturerDataModel manufacturer)
        {
            _database.CarManufacturers.Remove(manufacturer);
            _database.SaveChanges();
            return true;
        }
    }
}
