using Rentacar.BusinessModels.UserInfo;

namespace Rentacar.BusinessLogic.Interfaces
{
    public interface IUserInfoBusinessLogic
    {
        UserInfoDetailsBusinessModel GetDetailsByID(int id);
        IEnumerable<UserInfoDetailsBusinessModel> GetDetailsByUserID(string id);
        UserInfoDetailsBusinessModel Insert(UserInfoCreateBusinessModel userInfo);
    }
}
