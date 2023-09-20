using Microsoft.EntityFrameworkCore;
using Rentacar.Data;
using Rentacar.DataModels;
using Rentacar.Services.Interfaces;

namespace Rentacar.Services
{
    public class DbCarModelService : ICarModelService
    {
        private readonly ApplicationDbContext _database;

        public DbCarModelService(ApplicationDbContext database)
        {
            _database = database;
        }

        public IEnumerable<CarModelDataModel> GetAll()
        {
            return _database.CarModels.Include(m => m.Manufacturer);
        }

        public IEnumerable<CarModelDataModel> GetByManufacturerID(int id)
        {
            return _database.CarModels.Include(m => m.Manufacturer).Where(m => m.Manufacturer.ID == id);
        }

        public CarModelDataModel GetById(int id)
        {
            return _database.CarModels.Include(m => m.Manufacturer).FirstOrDefault(m => m.ID == id);
        }

        public CarModelDataModel Insert(CarModelDataModel model)
        {
            _database.CarModels.Add(model);
            _database.SaveChanges();
            return model;
        }

        public CarModelDataModel Update(CarModelDataModel model)
        {
            _database.CarModels.Update(model);
            _database.SaveChanges();
            return model;
        }

        public bool Delete(CarModelDataModel model)
        {
            _database.CarModels.Remove(model);
            _database.SaveChanges();
            return true;
        }
    }
}
