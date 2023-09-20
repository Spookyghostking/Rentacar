using Rentacar.DataModels;

namespace Rentacar.BusinessModels.Reservation
{
    public class ReservationCreateBusinessModel
    {
        public int ID { get; set; }
        public int UserInfoID { get; set; }
        public int CarID { get; set; }
        public DateTime ReservationBegin { get; set; }
        public DateTime ReservationEnd { get; set; }
    }
}
