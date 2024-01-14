using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Rentacar.BusinessLogic.Interfaces;
using Rentacar.BusinessModels.IdentificationDocumentImage;
using Rentacar.BusinessModels.UserInfo;
using Rentacar.DataModels;
using Rentacar.Services.Interfaces;

namespace Rentacar.BusinessLogic
{
    public class UserInfoBusinessLogic : IUserInfoBusinessLogic
    {
        private readonly IMapper _mapper;
        private readonly IUserInfoService _userInfo;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IIdentificationDocumentImageService _identificationImages;
        private readonly IIdentificationDocumentTypeService _identificationTypes;

        public UserInfoBusinessLogic(
            IMapper mapper, 
            IUserInfoService userInfo,
            UserManager<IdentityUser> userManager,
            IIdentificationDocumentImageService identificationImages,
            IIdentificationDocumentTypeService identificationTypes)
        {
            _mapper = mapper;
            _userInfo = userInfo;
            _userManager = userManager;
            _identificationImages = identificationImages;
            _identificationTypes = identificationTypes;
        }

        public UserInfoDetailsBusinessModel GetDetailsByID(int id)
        {
            UserInfoDataModel userInfoData = _userInfo.GetByID(id);
            UserInfoDetailsBusinessModel userInfo = _mapper.Map<UserInfoDetailsBusinessModel>(userInfoData);
            IEnumerable<IdentificationDocumentImageDataModel> images = _identificationImages.GetByUserInfoID(userInfo.ID);
            userInfo.IdentificationImages = _mapper.Map<IEnumerable<IdentificationDocumentImageBusinessModel>>(images);
            return userInfo;
        }

        public async Task<IdentityUser> GetUserByUserInfoIDAsync(int userInfoID)
        {
            UserInfoDataModel userInfo = _userInfo.GetByID(userInfoID);
            IdentityUser user = await _userManager.FindByIdAsync(userInfo.User.Id);
            return user;
        }

        public IEnumerable<UserInfoDetailsBusinessModel> GetDetailsByUserID(string id)
        {
            IEnumerable<UserInfoDataModel> userInfo = _userInfo.GetByUserID(id);
            IEnumerable<UserInfoDetailsBusinessModel> userInfoDetails = _mapper.Map<IEnumerable<UserInfoDetailsBusinessModel>>(userInfo);

            foreach (var info in userInfoDetails)
            {
                IEnumerable<IdentificationDocumentImageDataModel> imageData = _identificationImages.GetByUserInfoID(info.ID);
                info.IdentificationImages = _mapper.Map<IEnumerable<IdentificationDocumentImageBusinessModel>>(imageData);
            }

            return userInfoDetails;
        }

        public UserInfoDetailsBusinessModel Insert(UserInfoCreateBusinessModel userInfo)
        {
            UserInfoDataModel userInfoData = _mapper.Map<UserInfoDataModel>(userInfo);
            userInfoData.IdentificationType = _identificationTypes.GetByID(userInfo.IdentificationTypeID);
            if (userInfo.IdentificationImages != null)
            {
                userInfoData = _userInfo.Insert(userInfoData, userInfo.IdentificationImages);
            } else
            {
                userInfoData = _userInfo.Insert(userInfoData);
            }
            var userInfoDetails = _mapper.Map<UserInfoDetailsBusinessModel>(userInfoData);


            IEnumerable<IdentificationDocumentImageDataModel> images = _identificationImages.GetByUserInfoID(userInfoDetails.ID);
            userInfoDetails.IdentificationImages = _mapper.Map<IEnumerable<IdentificationDocumentImageBusinessModel>>(images);

            return userInfoDetails;
        }
    }
}
