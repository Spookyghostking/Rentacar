using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Rentacar.BusinessModels.Reservation
{
    public class ReservationEditAdminBusinessModel
    {
        [Required]
        public int ID { get; set; }
        [Required]
        public int UserInfoID { get; set; }
        [Required]
        public int CarID { get; set; }
        [Required]
        public int StatusID { get; set; }
        [Required]
        public DateTime ReservationBegin { get; set; }
        [Required]
        public DateTime ReservationEnd { get; set; }
        public List<SelectListItem>? StatusOptions { get; set; }
    }
}
