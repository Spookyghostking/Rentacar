using Microsoft.EntityFrameworkCore;
using Rentacar.BusinessModels.CarImage;
using Rentacar.Data;
using Rentacar.DataModels;
using Rentacar.Services.Interfaces;

namespace Rentacar.Services
{
    public class DbCarImageService : ICarImageService
    {
        private readonly ApplicationDbContext _database;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public DbCarImageService(ApplicationDbContext database, IWebHostEnvironment webHostEnvironment)
        {
            _database = database;
            _webHostEnvironment = webHostEnvironment;
        }

        public CarImageDataModel GetByID(int id)
        {
            return _database.CarImages.Include(i => i.Car).FirstOrDefault(i => i.ID == id);
        }

        public IEnumerable<CarImageDataModel> GetByCarID(int id)
        {
            return _database.CarImages.Include(i => i.Car).Where(i => i.Car.ID == id);
        }

        public CarImageDataModel Insert(CarImageCreateBusinessModel image)
        {
            string fileName = "";
            string url = "";
            string path = "";
            do
            {
                fileName = Guid.NewGuid().ToString() + ".jpg";
                url = "img/Car/" + fileName;
                path = Path.Combine(_webHostEnvironment.WebRootPath, url);
            } while (File.Exists(path));

            FileStream fileStream = new FileStream(path, FileMode.Create);
            image.Image.CopyTo(fileStream);
            fileStream.Close();
            
            CarImageDataModel imageData = new CarImageDataModel();
            imageData.Car = _database.Cars.FirstOrDefault(c => c.ID == image.CarID);
            imageData.Url = "/" + url;
            
            _database.CarImages.Add(imageData);
            _database.SaveChanges();
            return imageData;
        }

        public CarImageDataModel Delete(CarImageDataModel image)
        {
            string path = image.Url;
            path = path.Replace("/", "\\");
            path = path.Remove(0, 1);
            path = Path.Combine(_webHostEnvironment.WebRootPath, path);
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            _database.CarImages.Remove(image);
            _database.SaveChanges();
            return image;
        }
    }
}
