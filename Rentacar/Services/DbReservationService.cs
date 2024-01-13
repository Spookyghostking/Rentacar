using Microsoft.EntityFrameworkCore;
using Rentacar.Data;
using Rentacar.DataModels;
using Rentacar.Services.Interfaces;
using Rentacar.Services.Enums;

namespace Rentacar.Services
{
    namespace Enums
    {
        enum ReservationStatuses
        {
            Cart = 1,
            Reserved,
            Active,
            Archived,
            Remove
        }
    }

    public class DbReservationService : IReservationService
    {
        private readonly ApplicationDbContext _database;

        public DbReservationService(ApplicationDbContext database)
        {
            _database = database;
        }

        public IEnumerable<ReservationDataModel> GetAll()
        {
            return _database.Reservations
                .Include(r => r.UserInfo)
                .Include(r => r.Car)
                .Include(r => r.Status);
        }

        public ReservationDataModel GetById(int id)
        {
            return _database.Reservations
                .Include(r => r.UserInfo)
                .Include(r => r.Car)
                .Include(r => r.Status)
                .FirstOrDefault(r => r.ID == id);
        }

        public IEnumerable<ReservationDataModel> GetbyUser(string userID)
        {
            IEnumerable<ReservationDataModel> reservations = _database.Reservations
                .Include(r => r.Car)
                .Include(r => r.Status)
                .Include(r => r.UserInfo)
                .Include(r => r.UserInfo.User)
                .Where(r => r.UserInfo.User.Id == userID);
            return reservations;
        }

        public ReservationDataModel Insert(ReservationDataModel reservation)
        {
            _database.Reservations.Add(reservation);
            _database.SaveChanges();
            return reservation;
        }

        public ReservationDataModel Update(ReservationDataModel reservation)
        {
            _database.Reservations.Update(reservation);
            _database.SaveChanges();
            return reservation;
        }

        public bool Delete(ReservationDataModel reservation)
        {
            if (reservation.Status.ID == (int)ReservationStatuses.Cart ||
                reservation.Status.ID == (int)ReservationStatuses.Remove)
            {
                _database.Remove(reservation);
                _database.SaveChanges(true);
            } else
            {
                reservation.Status = _database.ReservationStatuses.FirstOrDefault(
                    s => s.ID == (int)ReservationStatuses.Remove);
                Update(reservation);
            }
            return true;
        }
    }
}
