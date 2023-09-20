using Rentacar.DataModels;

namespace Rentacar.Services.Interfaces
{
    public interface IUserInfoService
    {
        UserInfoDataModel GetByID(int id);
        IEnumerable<UserInfoDataModel> GetByUserID(string id);
        UserInfoDataModel Insert(UserInfoDataModel userInfo);
        UserInfoDataModel Insert(UserInfoDataModel userInfo, IFormFileCollection images);
    }
}
