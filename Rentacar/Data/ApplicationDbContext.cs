using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Rentacar.DataModels;
using Rentacar.BusinessModels.CarImage;
using Rentacar.BusinessModels.CarModel;
using Rentacar.BusinessModels.CarManufacturer;

namespace Rentacar.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<CarDataModel> Cars { get; set; }
        public DbSet<CarModelDataModel> CarModels { get; set; }
        public DbSet<CarManufacturerDataModel> CarManufacturers { get; set; }
        public DbSet<CarImageDataModel> CarImages { get; set; }
        public DbSet<IdentificationDocumentTypeDataModel> IdentificationTypes { get; set; }
        public DbSet<UserInfoDataModel> UserInfo { get; set; }
        public DbSet<IdentificationDocumentImageDataModel> IdentificationImages { get; set; }
        public DbSet<ReservationDataModel> Reservations { get; set; }
        public DbSet<ReservationStatusDataModel> ReservationStatuses { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<CarDataModel>()
                .HasData(new List<object>() {
                    new { ID = 1, CodeName = "Billy", LicencePlateNumber = "HB1840BS", CarModelID = 1, ManufacturedYear = 2002, DailyFee = 20.0f, FixedFee = 20.0f, DateAdded = DateTime.Now },
                    new { ID = 2, CodeName = "Sam", LicencePlateNumber = "70UGHC4R", CarModelID = 2, ManufacturedYear = 2008, DailyFee = 25.0f, FixedFee = 30.0f, DateAdded = DateTime.Now },
                    new { ID = 3, CodeName = "Sean", LicencePlateNumber = "CR055", CarModelID = 3, ManufacturedYear = 2010, DailyFee = 30.0f, FixedFee = 40.0f, DateAdded = DateTime.Now },
                    new { ID = 4, CodeName = "Henry", LicencePlateNumber = "S4D801", CarModelID = 4, ManufacturedYear = 1996, DailyFee = 10.0f, FixedFee = 12.0f, DateAdded = DateTime.Now },
                });
            builder.Entity<CarManufacturerDataModel>()
                .HasData(new List<object>()
                {
                    new { ID = 1, Name = "Ford" },
                    new { ID = 2, Name = "Toyota" }
                });
            builder.Entity<CarModelDataModel>()
                .HasData(new List<object>()
                {
                    new { ID = 1, ManufacturerID = 1, Name = "Focus" },
                    new { ID = 2, ManufacturerID = 2, Name = "Corolla" },
                    new { ID = 3, ManufacturerID = 2, Name = "Corolla Cross" },
                    new { ID = 4, ManufacturerID = 1, Name = "Sierra" },
                });
            builder.Entity<CarImageDataModel>()
                .HasData(new List<object>()
                {
                    new { ID = 1, Url = "/img/Car/Test.png", CarID = 1 }
                });
            builder.Entity<IdentificationDocumentTypeDataModel>()
                .HasData(new List<object>()
                {
                    new { ID = 1, Value = "National Identity Card" },
                    new { ID = 2, Value = "Passport" },
                    new { ID = 3, Value = "Driver's Licence" },
                    new { ID = 4, Value = "Social Security Card" }
                });
            builder.Entity<UserInfoDataModel>()
                .HasData(new List<object>()
                {

                });
            builder.Entity<IdentificationDocumentImageDataModel>()
                .HasData(new List<object>()
                {

                });
            builder.Entity<ReservationStatusDataModel>()
                .HasData(new List<object>()
                {
                    new { ID = 1, Value = "Cart" },
                    new { ID = 2, Value = "Reserved" },
                    new { ID = 3, Value = "Active" },
                    new { ID = 4, Value = "Archived" },
                    new { ID = 5, Value = "Remove" }
                });
            builder.Entity<ReservationDataModel>()
                .HasData(new List<object>()
                {
                });
        }
    }
}
