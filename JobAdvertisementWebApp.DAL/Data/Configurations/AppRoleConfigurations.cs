using JobAdvertisementWebApp.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobAdvertisementWebApp.DAL.Data.Configurations
{
    public class AppRoleConfigurations : IEntityTypeConfiguration<AppRole>
    {
        public void Configure(EntityTypeBuilder<AppRole> builder)
        {
            builder.Property(x => x.Id).IsRequired(true);
            builder.Property(x => x.Role).IsRequired(true);
            builder.HasIndex(x => new { x.Id, x.Role }).IsUnique(true);
            builder.HasData(new AppRole {Id=1, Role = Roles.Employer }, new AppRole {Id=2, Role = Roles.Member });
        }
    }
}
