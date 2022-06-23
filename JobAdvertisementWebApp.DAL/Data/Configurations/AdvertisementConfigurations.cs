using JobAdvertisementWebApp.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobAdvertisementWebApp.DAL.Data.Configurations
{
    public class AdvertisementConfigurations : IEntityTypeConfiguration<Advertisement>
    {
        public void Configure(EntityTypeBuilder<Advertisement> builder)
        {
            builder.Property(x => x.Id).IsRequired(true);
            builder.Property(x => x.CompanyName).IsRequired(true);
            builder.Property(x => x.Title).IsRequired(true);
            builder.Property(x => x.Defination).IsRequired(true);
            builder.Property(x => x.CreatedDate).HasDefaultValueSql("getdate()");
            builder.Property(x => x.CompanyId).IsRequired(true);
            builder.Property(x => x.IsActive).IsRequired(true);

            builder.HasOne(x => x.Company).WithMany(x => x.Advertisements).HasForeignKey(x => x.CompanyId);
        }
    }
}
