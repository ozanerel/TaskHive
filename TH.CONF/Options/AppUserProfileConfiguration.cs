using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TH.ENTITIES.Models;

namespace TH.CONF.Options
{
    public class AppUserProfileConfiguration : BaseConfiguration<AppUserProfile>
    {
        public override void Configure(EntityTypeBuilder<AppUserProfile> builder)
        {

            base.Configure(builder);
            // Configure the one-to-one relationship with AppUser
            builder.Property(x => x.FirstName)
                   .IsRequired()
                   .HasMaxLength(50);
            builder.Property(x => x.LastName)
                    .IsRequired()
                    .HasMaxLength(50);
        }
    }
}
