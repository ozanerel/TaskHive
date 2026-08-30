using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TH.ENTITIES.Models;

namespace TH.CONF.Options
{
    public class UserConfiguration : BaseConfiguration<User>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            base.Configure(builder);
            builder.Property(u => u.FirstName)
                   .IsRequired()
                   .HasMaxLength(50);
            builder.Property(u => u.LastName)
                   .IsRequired()
                   .HasMaxLength(50);
            builder.Property(u => u.Email)
                   .IsRequired()
                   .HasMaxLength(100);
            builder.Property(x => x.UserTag)
                    .IsRequired()
                    .HasMaxLength(7);
            builder.HasIndex(x => x.UserTag)
                    .IsUnique();
            builder.HasOne(u => u.Role)
                   .WithMany(r => r.Users)
                   .HasForeignKey(u => u.RoleId);
        }
    }
}
