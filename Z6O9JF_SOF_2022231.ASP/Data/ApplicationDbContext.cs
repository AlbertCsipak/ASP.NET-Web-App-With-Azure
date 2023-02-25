using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using Z6O9JF_SOF_2022231.ASP.Models;

namespace Z6O9JF_SOF_2022231.ASP.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<SiteUser> Users { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Car>(entity =>
            {
                entity.HasOne(car => car.Owner).WithMany(Owner => Owner.Cars).HasForeignKey(car => car.OwnerID).OnDelete(DeleteBehavior.Cascade);
            });
            builder.Entity<Appointment>(entity =>
            {
                entity.HasOne(appointment => appointment.MyCar).WithMany(car => car.Appointments).HasForeignKey(appointment => appointment.CarID).OnDelete(DeleteBehavior.Cascade);
            });

            builder.Entity<IdentityRole>().HasData(
            new { Id = "1", Name = "Admin", NormalizedName = "ADMIN" }
            );


            PasswordHasher<SiteUser> ph = new PasswordHasher<SiteUser>();
            SiteUser admin = new SiteUser
            {
                Id = Guid.NewGuid().ToString(),
                Email = "admin@admin.com",
                EmailConfirmed = true,
                UserName = "admin@admin.com",
                NormalizedUserName = "ADMIN@ADMIN.COM",
                FirstName = "Admin",
                LastName = "Admin"
            };
            admin.PasswordHash = ph.HashPassword(admin, "123456");
            builder.Entity<SiteUser>().HasData(admin);

            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = "1",
                UserId = admin.Id
            });

            base.OnModelCreating(builder);
        }

    }
}