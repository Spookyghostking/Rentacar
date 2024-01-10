using Rentacar.BusinessModels.Car;
using Rentacar.BusinessModels.UserInfo;

namespace Rentacar.BusinessModels.Reservation
{
    public class ReservationDetailsBusinessModel
    {
        public int ID { get; set; }
        public int UserInfoID { get; set; }
        public int CarID { get; set; }
        public DateTime ReservationBegin { get; set; }
        public DateTime ReservationEnd { get; set; }
        public string StatusValue { get; set; }
        public DateTime DateAdded { get; set; }
    }
}
