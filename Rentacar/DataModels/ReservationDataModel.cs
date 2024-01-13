using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Rentacar.DataModels
{
    public class ReservationDataModel
    {
        public int ID { get; set; }
        [Required]
        public UserInfoDataModel UserInfo { get; set; }
        [Required]
        public CarDataModel Car { get; set; }
        [Required]
        public DateTime ReservationBegin { get; set; }
        [Required]
        public DateTime ReservationEnd { get; set; }
        [Required]
        public ReservationStatusDataModel Status { get; set; }
        [Required]
        public DateTime DateAdded { get; set; }
    }
}
