using Rentacar.Data;
using Rentacar.DataModels;
using Rentacar.Services.Interfaces;

namespace Rentacar.Services
{
    public class DbIdentificationDocumentTypeService : IIdentificationDocumentTypeService
    {
        private readonly ApplicationDbContext _database;

        public DbIdentificationDocumentTypeService(ApplicationDbContext database)
        {
            _database = database;
        }

        public IEnumerable<IdentificationDocumentTypeDataModel> GetAll()
        {
            return _database.IdentificationTypes;
        }

        public IdentificationDocumentTypeDataModel GetByID(int id)
        {
            return _database.IdentificationTypes.FirstOrDefault(t => t.ID == id);
        }
    }
}
