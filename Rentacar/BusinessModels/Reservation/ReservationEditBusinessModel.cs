namespace Rentacar.BusinessModels.Reservation
{
    public class ReservationEditBusinessModel
    {
        public int ID { get; set; }
        public int UserInfoID { get; set; }
        public int CarID { get; set; }
        public int StatusID { get; set; }
        public DateTime ReservationBegin { get; set; }
        public DateTime ReservationEnd { get; set; }
    }
}
