using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using NabcoPortal.Models;

namespace NabcoPortal.Persistent
{
    public class UserDbContext : IdentityDbContext<ApplicationUser>
    {
        public UserDbContext()
            : base("NabcoDbConnection", throwIfV1Schema: false)
        {
        }

        public static UserDbContext Create()
        {
            return new UserDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema("User");
            modelBuilder.Entity<IdentityUser>().ToTable("Users");
            modelBuilder.Entity<ApplicationUser>().ToTable("Users");
            modelBuilder.Entity<IdentityUserRole>().ToTable("UserRoles");
            modelBuilder.Entity<IdentityRole>().ToTable("Roles");
            modelBuilder.Entity<IdentityUserLogin>().ToTable("UserLogins");
            modelBuilder.Entity<IdentityUserClaim>().ToTable("UserClaims");

        }
    }

    public class UserDbContextConfiguration : DbConfiguration
    {
        public UserDbContextConfiguration()
        {
            this.SetDatabaseInitializer(new NullDatabaseInitializer<UserDbContext>());
        }
    }
}