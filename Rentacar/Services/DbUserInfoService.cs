using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Rentacar.Data;
using Rentacar.DataModels;
using Rentacar.Services.Interfaces;

namespace Rentacar.Services
{
    public class DbUserInfoService : IUserInfoService
    {
        private readonly ApplicationDbContext _database;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public DbUserInfoService(
            ApplicationDbContext database,
            IWebHostEnvironment webHostEnvironment)
        {
            _database = database;
            _webHostEnvironment = webHostEnvironment;
        }

        public UserInfoDataModel GetByID(int id)
        {
            return _database.UserInfo
                .Include(info => info.User)
                .Include(info => info.IdentificationType)
                .FirstOrDefault(info => info.ID == id);
        }

        public IEnumerable<UserInfoDataModel> GetByUserID(string id)
        {
            return _database.UserInfo
                .Include(info => info.User)
                .Include(info => info.IdentificationType)
                .Where(info => info.User.Id == id);
        }

        public UserInfoDataModel Insert(UserInfoDataModel userInfo)
        {
            _database.UserInfo.Add(userInfo);
            _database.SaveChanges();
            return userInfo;

        }

        public UserInfoDataModel Insert(UserInfoDataModel userInfo, IFormFileCollection images)
        {
            userInfo = Insert(userInfo);
            foreach (var image in images)
            {
                string fileName = "";
                string url = "";
                string path = "";
                do
                {
                    fileName = Guid.NewGuid().ToString() + ".jpg";
                    url = "img/Identification/" + fileName;
                    path = Path.Combine(_webHostEnvironment.WebRootPath, url);
                } while (File.Exists(path));

                FileStream fileStream = new FileStream(path, FileMode.Create);
                image.CopyTo(fileStream);
                fileStream.Close();

                IdentificationDocumentImageDataModel imageData = new IdentificationDocumentImageDataModel();
                imageData.UserInfo = userInfo;
                imageData.Url = "/" + url;

                _database.IdentificationImages.Add(imageData);
                _database.SaveChanges();
            }
            return userInfo;
        }
    }
}
