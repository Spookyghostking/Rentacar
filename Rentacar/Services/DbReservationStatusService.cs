using Microsoft.EntityFrameworkCore;
using Rentacar.Data;
using Rentacar.DataModels;
using Rentacar.Services.Interfaces;

namespace Rentacar.Services
{
    public class DbReservationStatusService : IReservationStatusService
    {
        private readonly ApplicationDbContext _database;

        public DbReservationStatusService(ApplicationDbContext database)
        {
            _database = database;
        }

        public ReservationStatusDataModel GetByID(int id)
        {
            return _database.ReservationStatuses.FirstOrDefault(s => s.ID == id);
        }
    }
}
