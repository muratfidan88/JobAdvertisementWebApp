using JobAdvertisementWebApp.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobAdvertisementWebApp.DAL.Data.Configurations
{
    public class MemberCvConfigurations : IEntityTypeConfiguration<MemberCv>
    {
        public void Configure(EntityTypeBuilder<MemberCv> builder)
        {
            builder.Property(x => x.Id).IsRequired(true);
            builder.Property(x => x.Name).IsRequired(true);
            builder.Property(x => x.LastName).IsRequired(true);
            builder.Property(x => x.BirthDate).IsRequired(true);
            builder.Property(x => x.Address).IsRequired(true);
            builder.Property(x => x.MailAddress).IsRequired(true);
            builder.Property(x => x.PhoneNumber).IsRequired(true);
            builder.Property(x => x.SchoolName).IsRequired(true);
            builder.Property(x => x.UserId).IsRequired(true);

            builder.HasOne(x => x.AppUser).WithOne(x => x.MemberCv).HasForeignKey<MemberCv>(x => x.UserId);
        }
    }
}
