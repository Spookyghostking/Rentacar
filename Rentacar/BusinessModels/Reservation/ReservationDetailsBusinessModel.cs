using Rentacar.BusinessModels.Car;
using Rentacar.BusinessModels.UserInfo;
using System.ComponentModel.DataAnnotations;

namespace Rentacar.BusinessModels.Reservation
{
    public class ReservationDetailsBusinessModel
    {
        public int ID { get; set; }
        [Display(Name = "User Info ID")]
        public int UserInfoID { get; set; }
        [Display(Name = "Car ID")]
        public int CarID { get; set; }
        [Display(Name = "Reservation Begin Date")]
        public DateTime ReservationBegin { get; set; }
        [Display(Name = "Reservation End Date")]
        public DateTime ReservationEnd { get; set; }
        [Display(Name = "Status")]
        public string StatusValue { get; set; }
        [Display(Name = "Date Added")]
        public DateTime DateAdded { get; set; }
    }
}
