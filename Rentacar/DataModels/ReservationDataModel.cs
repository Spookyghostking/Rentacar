using Microsoft.AspNetCore.Identity;

namespace Rentacar.DataModels
{
    public class ReservationDataModel
    {
        public int ID { get; set; }
        public UserInfoDataModel UserInfo { get; set; }
        public CarDataModel Car { get; set; }
        public DateTime ReservationBegin { get; set; }
        public DateTime ReservationEnd { get; set; }
        public ReservationStatusDataModel Status { get; set; }
        public DateTime DateAdded { get; set; }
    }
}
