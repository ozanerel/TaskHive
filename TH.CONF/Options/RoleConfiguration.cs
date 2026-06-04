using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TH.ENTITIES.Models;

namespace TH.CONF.Options
{
    public class RoleConfiguration:BaseConfiguration<Role>
    {
        public override void Configure(EntityTypeBuilder<Role> builder)
        {
            base.Configure(builder);
            builder.Property(r => r.Name)
                   .IsRequired()
                   .HasMaxLength(50);
            builder.Property(r => r.Description)
                   .HasMaxLength(250);
        }
    }
}
