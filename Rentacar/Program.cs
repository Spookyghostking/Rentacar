using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Rentacar.BusinessLogic;
using Rentacar.BusinessLogic.Interfaces;
using Rentacar.Data;
using Rentacar.Mapper;
using Rentacar.Services;
using Rentacar.Services.Interfaces;

namespace Rentacar
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            string connectionString = builder.Configuration.GetConnectionString("Test");
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });
            builder.Services.AddDefaultIdentity<IdentityUser>(options =>
            {
                options.SignIn.RequireConfirmedEmail = false;
            }).AddEntityFrameworkStores<ApplicationDbContext>();

            builder.Services.AddAutoMapper(options =>
            {
                options.AddProfile<CarModelProfile>();
                options.AddProfile<CarProfile>();
                options.AddProfile<CarImageProfile>();
                options.AddProfile<CarManufacturerProfile>();
                options.AddProfile<UserInfoProfile>();
                options.AddProfile<IdentificationDocumentImageProfile>();
                options.AddProfile<IdentificationDocumentTypeProfile>();
            });

            builder.Services.AddScoped<ICarService, DbCarService>();
            builder.Services.AddScoped<ICarManufacturerService, DbCarManufacturerService>();
            builder.Services.AddScoped<ICarModelService, DbCarModelService>();
            builder.Services.AddScoped<ICarImageService, DbCarImageService>();
            builder.Services.AddScoped<IUserInfoService, DbUserInfoService>();
            builder.Services.AddScoped<IIdentificationDocumentImageService, DbIdentificationDocumentImageService>();
            builder.Services.AddScoped<IIdentificationDocumentTypeService, DbIdentificationDocumentTypeService>();
            builder.Services.AddScoped<ICarBusinessLogic, CarBusinessLogic>();
            builder.Services.AddScoped<ICarModelBusinessLogic, CarModelBusinessLogic>();
            builder.Services.AddScoped<ICarImageBusinessLogic, CarImageBusinessLogic>();
            builder.Services.AddScoped<ICarManufacturerBusinessLogic, CarManufacturerBusinessLogic>();
            builder.Services.AddScoped<IUserInfoBusinessLogic, UserInfoBusinessLogic>();
            builder.Services.AddScoped<IIdentificationDocumentTypeBusinessLogic, IdentificationDocumentTypeBusinessLogic>();

            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapRazorPages();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}