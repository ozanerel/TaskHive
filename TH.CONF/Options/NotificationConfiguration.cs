using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TH.ENTITIES.Models;

namespace TH.CONF.Options
{
    public class NotificationConfiguration:BaseConfiguration<Notification>
    {
        public override void Configure(EntityTypeBuilder<Notification> builder)
        {
            base.Configure(builder);
            builder.Property(n => n.Title)
                   .IsRequired()
                   .HasMaxLength(100);
            builder.Property(n => n.Message)
                   .IsRequired()
                   .HasMaxLength(500);
            builder.HasOne(n => n.User)
                   .WithMany(u => u.Notifications)
                   .HasForeignKey(n => n.UserId);
        }
    }
}
