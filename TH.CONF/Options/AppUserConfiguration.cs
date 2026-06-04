using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TH.ENTITIES.Models;

namespace TH.CONF.Options
{
    public class AppUserConfiguration:BaseConfiguration<AppUser>
    {
        public override void Configure(EntityTypeBuilder<AppUser> builder)
        {
            base.Configure(builder);


            builder.HasOne(u => u.AppUserProfile)
                   .WithOne(p => p.AppUser)
                   .HasForeignKey<AppUserProfile>(p => p.AppUserId);

            
        }
    }
}
