using JobAdvertisementWebApp.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobAdvertisementWebApp.DAL.Data.Configurations
{
    public class ApplicationConfigurations : IEntityTypeConfiguration<Application>
    {
        public void Configure(EntityTypeBuilder<Application> builder)
        {
            builder.Property(x => x.Id).IsRequired(true);
            builder.Property(x => x.AdvertisementId).IsRequired(true);
            builder.Property(x => x.UserId).IsRequired(true);
            builder.Property(x => x.CreatedDate).HasDefaultValueSql("getdate()");

            builder.HasOne(x => x.AppUser).WithMany(x => x.Applications).HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Advertisement).WithMany(x => x.Applications).HasForeignKey(x => x.AdvertisementId).OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(x => new { x.UserId, x.AdvertisementId }).IsUnique(true);
        }
    }
}
