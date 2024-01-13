using AutoMapper;
using Rentacar.BusinessModels.Reservation;
using Rentacar.DataModels;

namespace Rentacar.Mapper
{
    public class ReservationProfile : Profile
    {
        public ReservationProfile()
        {
            CreateMap<ReservationDataModel, ReservationDetailsBusinessModel>().ForMember(rd => rd.StatusValue, options =>
            {
                options.MapFrom(r => r.Status.Value);
            });
            CreateMap<ReservationCreateBusinessModel, ReservationDataModel>();

            CreateMap<ReservationEditBusinessModel, ReservationDataModel>();
            CreateMap<ReservationDataModel, ReservationEditBusinessModel>();

            CreateMap<ReservationDataModel, ReservationEditAdminBusinessModel>();
            CreateMap<ReservationEditAdminBusinessModel, ReservationDataModel>();
        }
    }
}
