using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TH.ENTITIES.Models;

namespace TH.CONF.Options
{
    public class TaskCommentConfiguration:BaseConfiguration<TaskComment>
    {
        public override void Configure(EntityTypeBuilder<TaskComment> builder)
        {
            base.Configure(builder);
            builder.Property(tc => tc.Message)
                   .IsRequired()
                   .HasMaxLength(500);
            builder.HasOne(tc => tc.Task)
                   .WithMany(t => t.TaskComments)
                   .HasForeignKey(tc => tc.TaskId);
            builder.HasOne(tc => tc.User)
                   .WithMany(u => u.TaskComments)
                   .HasForeignKey(tc => tc.UserId)
                   .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
