using JobAdvertisementWebApp.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobAdvertisementWebApp.DAL.Data.Configurations
{
    public class AppUserConfigurations : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.Property(x => x.Id).IsRequired(true);
            builder.Property(x => x.MailAddress).IsRequired(true);
            builder.Property(x => x.Password).IsRequired(true);
            builder.Property(x => x.Name).IsRequired(true);
            builder.Property(x => x.LastName).IsRequired(true);
            builder.Property(x => x.RoleId).IsRequired(true);

            builder.HasOne(x => x.AppRole).WithMany(x => x.AppUsers).HasForeignKey(x => x.RoleId);
        }
    }
}
