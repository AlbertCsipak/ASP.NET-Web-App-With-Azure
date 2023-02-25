using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Z6O9JF_SOF_2022231.ASP.Data;
using Z6O9JF_SOF_2022231.ASP.Logic;
using Z6O9JF_SOF_2022231.ASP.Models;
using Z6O9JF_SOF_2022231.ASP.Repository;
using Z6O9JF_SOF_2022231.ASP.Services;
using Microsoft.AspNetCore.Identity;

namespace Z6O9JF_SOF_2022231.ASP
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddOutputCaching();

            builder.Services.AddTransient<ICarLogic, CarLogic>();
            builder.Services.AddTransient<IAppointmentLogic, AppointmentLogic>();

            builder.Services.AddTransient<IAppointmentRepository, AppointmentRepository>();
            builder.Services.AddTransient<ICarRepository, CarRepository>();

            builder.Services.AddTransient<IEmailSender, EmailSender>();

            //Database
            //Local
            //var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            //Azure
            var connectionString = builder.Configuration.GetConnectionString("AzureConnection") ?? throw new InvalidOperationException("Connection string 'AzureConnection' not found.");

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString).UseLazyLoadingProxies());
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            //Login Settings
            builder.Services.AddDefaultIdentity<SiteUser>(options =>
            {
                options.SignIn.RequireConfirmedAccount = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 3;

            })
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            //FBLogin
            builder.Services.AddAuthentication().AddFacebook(opt =>
            {
                opt.AppId = "705580851104998";
                opt.AppSecret = "c19676dc78b5058e88fe89288b2537a2";
            });

            //app Settings
            var app = builder.Build();
            app.UseExceptionHandler("/Car/Error");
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseOutputCaching();
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapRazorPages();

            app.Run();
        }
    }
}