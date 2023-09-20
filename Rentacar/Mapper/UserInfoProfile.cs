using AutoMapper;
using Rentacar.BusinessModels.UserInfo;
using Rentacar.DataModels;

namespace Rentacar.Mapper
{
    public class UserInfoProfile : Profile
    {
        public UserInfoProfile()
        {
            CreateMap<UserInfoCreateBusinessModel, UserInfoDataModel>();
            CreateMap<UserInfoDataModel, UserInfoDetailsBusinessModel>();
        }
    }
}
