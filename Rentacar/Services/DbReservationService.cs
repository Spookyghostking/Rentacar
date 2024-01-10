using Microsoft.EntityFrameworkCore;
using Rentacar.Data;
using Rentacar.DataModels;
using Rentacar.Services.Interfaces;

namespace Rentacar.Services
{
    enum ReservationStatuses
    {
        Cart = 1,
        Reserved,
        Active,
        Archived,
        Remove
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
            if (reservation.Status.ID == (int)ReservationStatuses.Cart)
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
