using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace RWA_Projekt_MVC.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class RwaUser : IdentityUser<int, RwaUserLogin, RwaUserRole, RwaUserClaim>
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<RwaUser, int> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class RwaIdentityDbContext : IdentityDbContext<RwaUser, RwaRole, int, RwaUserLogin, RwaUserRole, RwaUserClaim>
    {
        public RwaIdentityDbContext()
            : base("DefaultConnection")
        {
        }

        public static RwaIdentityDbContext Create()
        {
            return new RwaIdentityDbContext();
        }

        public System.Data.Entity.DbSet<RWA_Projekt_MVC.Models.Apartment> Apartments { get; set; }

        public System.Data.Entity.DbSet<RWA_Projekt_MVC.Models.City> Cities { get; set; }

        public System.Data.Entity.DbSet<RWA_Projekt_MVC.Models.ApartmentReservation> ApartmentReservations { get; set; }
    }
    public class RwaRole : IdentityRole<int, RwaUserRole>
    {
        public RwaRole() { }
        public RwaRole(string name) { Name = name; }
    }

    public class RwaUserRole : IdentityUserRole<int> { }

    public class RwaUserClaim : IdentityUserClaim<int> { }

    public class RwaUserLogin : IdentityUserLogin<int> { }
}