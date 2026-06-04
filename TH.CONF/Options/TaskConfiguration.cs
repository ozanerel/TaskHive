using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TH.ENTITIES.Models;

namespace TH.CONF.Options
{
    public class TaskConfiguration : BaseConfiguration<ENTITIES.Models.Task>
    {
        public override void Configure(EntityTypeBuilder<ENTITIES.Models.Task> builder)
        {
            base.Configure(builder);
            builder.Property(t => t.Title)
                   .IsRequired()
                   .HasMaxLength(100);
            builder.Property(t => t.Description)
                   .IsRequired()
                   .HasMaxLength(250);
        }
    }
}
