using Microsoft.EntityFrameworkCore;
using Rentacar.Data;
using Rentacar.DataModels;
using Rentacar.Services.Interfaces;

namespace Rentacar.Services
{
    public class DbIdentificationDocumentImageService : IIdentificationDocumentImageService
    {
        private readonly ApplicationDbContext _database;

        public DbIdentificationDocumentImageService(ApplicationDbContext database)
        {
            _database = database;
        }
        public IEnumerable<IdentificationDocumentImageDataModel> GetByUserInfoID(int id)
        {
            return _database.IdentificationImages
                .Include(image => image.UserInfo)
                .Where(image => image.UserInfo.ID == id);
        }
    }
}
