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
    public class CompanyConfigurations : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.Property(x => x.Id).IsRequired(true);
            builder.Property(x => x.Name).IsRequired(true);
            builder.Property(x => x.Defination).IsRequired(true);
            builder.Property(x => x.Address).IsRequired(true);
            builder.Property(x => x.UserId).IsRequired(true);

            builder.HasOne(x => x.AppUser).WithMany(x => x.Companies).HasForeignKey(x => x.UserId);
        }
    }
}
