using JobAdvertisementWebApp.DAL.Data.Configurations;
using JobAdvertisementWebApp.Entities;
using Microsoft.EntityFrameworkCore;

namespace JobAdvertisementWebApp.DAL.Data.Contexts
{
    public class JobAdvertisementContext : DbContext
    {
        public JobAdvertisementContext(DbContextOptions<JobAdvertisementContext> options):base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AppUserConfigurations());
            modelBuilder.ApplyConfiguration(new AppRoleConfigurations());
            modelBuilder.ApplyConfiguration(new MemberCvConfigurations());
            modelBuilder.ApplyConfiguration(new CompanyConfigurations());
            modelBuilder.ApplyConfiguration(new AdvertisementConfigurations());
            modelBuilder.ApplyConfiguration(new ApplicationConfigurations());
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<AppRole> AppRoles { get; set; }
        public DbSet<MemberCv> MemberCvs { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Advertisement> Advertisements { get; set; }
        public DbSet<Application> Applications { get; set; }

    }
}
