using Rentacar.Data;
using Rentacar.DataModels;
using Rentacar.Services.Interfaces;

namespace Rentacar.Services
{
    public class DbCarBodyTypeService : ICarBodyTypeService
    {
        private readonly ApplicationDbContext _database;

        public DbCarBodyTypeService(ApplicationDbContext database)
        {
            _database = database;
        }

        public IEnumerable<CarBodyTypeDataModel> GetAll()
        {
            return _database.CarBodyTypes;
        }

        public CarBodyTypeDataModel GetById(int id)
        {
            return _database.CarBodyTypes.FirstOrDefault(t => t.ID == id);
        }
    }
}
