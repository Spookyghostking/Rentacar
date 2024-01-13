using Rentacar.DataModels;
using System.ComponentModel.DataAnnotations;

namespace Rentacar.BusinessModels.Reservation
{
    public class ReservationCreateBusinessModel
    {
        //public int ID { get; set; }
        [Required]
        public int UserInfoID { get; set; }
        [Required]
        public int CarID { get; set; }
        [Required]
        public DateTime ReservationBegin { get; set; }
        [Required]
        public DateTime ReservationEnd { get; set; }
    }
}
