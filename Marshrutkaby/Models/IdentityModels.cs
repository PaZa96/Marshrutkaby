using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Marshrutkaby.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("MDB", throwIfV1Schema: false)
        {
        }

        public virtual DbSet<CarSet> CarSet { get; set; }
        public virtual DbSet<DataRoutesSet> DataRoutesSet { get; set; }
        public virtual DbSet<DriversSet> DriversSet { get; set; }
        public virtual DbSet<RegistrationSet> RegistrationSet { get; set; }
        public virtual DbSet<RoutesSet> RoutesSet { get; set; }
        public virtual DbSet<TimeSet> TimeSet { get; set; }
        public virtual DbSet<OrderSet> OrderSet { get; set; }
        public virtual DbSet<TransportCompanySet> TransportCompanySet { get; set; }
        public virtual DbSet<WayPointsSet> WayPointsSet { get; set; }
        public virtual DbSet<WayPointsTimeSet> WayPointsTimeSet { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}