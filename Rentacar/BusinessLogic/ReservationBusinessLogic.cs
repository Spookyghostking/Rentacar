using AutoMapper;
using Rentacar.BusinessLogic.Interfaces;
using Rentacar.BusinessModels.Reservation;
using Rentacar.DataModels;
using Rentacar.Services.Interfaces;

namespace Rentacar.BusinessLogic
{
    public class ReservationBusinessLogic : IReservationBusinessLogic
    {
        private readonly IReservationService _reservations;
        private readonly ICarService _cars;
        private readonly IUserInfoService _userInfo;
        private readonly IReservationStatusService _statuses;
        private readonly IMapper _mapper;

        public ReservationBusinessLogic(
            IReservationService reservations,
            ICarService cars,
            IUserInfoService userInfo,
            IReservationStatusService statuses,
            IMapper mapper)
        {
            _reservations = reservations;
            _cars = cars;
            _userInfo = userInfo;
            _statuses = statuses;
            _mapper = mapper;
        }

        public IEnumerable<ReservationDetailsBusinessModel> GetAll()
        {
            return _mapper.Map<IEnumerable<ReservationDetailsBusinessModel>>(_reservations.GetAll());
        }

        public ReservationDetailsBusinessModel GetDetails(int id)
        {
            return _mapper.Map<ReservationDetailsBusinessModel>(_reservations.GetById(id));
        }

        public ReservationEditBusinessModel GetEdit(int id)
        {
            return _mapper.Map<ReservationEditBusinessModel>(_reservations.GetById(id));
        }

        public ReservationEditAdminBusinessModel GetEditAdmin(int id)
        {
            return _mapper.Map<ReservationEditAdminBusinessModel>(_reservations.GetById(id));
        }

        public IEnumerable<ReservationDetailsBusinessModel> GetbyUser(string userID)
        {
            IEnumerable<ReservationDataModel> reservationData =  _reservations.GetbyUser(userID);
            IEnumerable<ReservationDetailsBusinessModel> reservations =
                _mapper.Map<IEnumerable<ReservationDetailsBusinessModel>>(reservationData);
            return reservations;
        }

        public ReservationDetailsBusinessModel Insert(ReservationCreateBusinessModel reservation)
        {
            ReservationDataModel reservationData = _mapper.Map<ReservationDataModel>(reservation);
            reservationData.Car = _cars.GetById(reservation.CarID);
            reservationData.UserInfo = _userInfo.GetByID(reservation.UserInfoID);
            reservationData.Status = _statuses.GetByID(1);
            reservationData = _reservations.Insert(reservationData);
            return _mapper.Map<ReservationDetailsBusinessModel>(reservationData);
        }

        public ReservationDetailsBusinessModel Update(ReservationEditBusinessModel reservation)
        {
            ReservationDataModel reservationData = _mapper.Map<ReservationDataModel>(reservation);
            reservationData.Car = _cars.GetById(reservation.CarID);
            reservationData.UserInfo = _userInfo.GetByID(reservation.UserInfoID);
            reservationData = _reservations.Update(reservationData);
            return _mapper.Map<ReservationDetailsBusinessModel>(reservationData);
        }

        public ReservationDetailsBusinessModel Update(ReservationEditAdminBusinessModel reservation)
        {
            ReservationDataModel reservationData = _mapper.Map<ReservationDataModel>(reservation);
            reservationData.Car = _cars.GetById(reservation.CarID);
            reservationData.UserInfo = _userInfo.GetByID(reservation.UserInfoID);
            reservationData.Status = _statuses.GetByID(reservation.StatusID);
            reservationData = _reservations.Update(reservationData);
            return _mapper.Map<ReservationDetailsBusinessModel>(reservationData);
        }

        public bool Confirm(int id)
        {
            ReservationDataModel reservation = _reservations.GetById(id);
            if (reservation != null && reservation.Status.ID == 1)
            {
                reservation.Status = _statuses.GetByID(2);
                _reservations.Update(reservation);
                return true;
            }
            return false;
        }

        public bool DeleteByID(int id)
        {
            ReservationDataModel reservation = _reservations.GetById(id);
            return _reservations.Delete(reservation);
        }
    }
}
