using Microsoft.AspNetCore.Identity;
using Rentacar.BusinessModels.UserInfo;

namespace Rentacar.BusinessLogic.Interfaces
{
    public interface IUserInfoBusinessLogic
    {
        UserInfoDetailsBusinessModel GetDetailsByID(int id);
        Task<IdentityUser> GetUserByUserInfoIDAsync(int userInfoID);
        IEnumerable<UserInfoDetailsBusinessModel> GetDetailsByUserID(string id);
        UserInfoDetailsBusinessModel Insert(UserInfoCreateBusinessModel userInfo);
    }
}
