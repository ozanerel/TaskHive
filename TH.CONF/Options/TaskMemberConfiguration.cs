using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TH.ENTITIES.Models;

namespace TH.CONF.Options
{
    public class TaskMemberConfiguration : IEntityTypeConfiguration<TaskMember>
    {
        public void Configure(EntityTypeBuilder<TaskMember> builder)
        {
            //Aynı kullanıcı aynı Task'a iki kez TaskMember olarak eklenemez. Bu yüzden composite key kullanıyoruz.
            builder.HasKey(x => new
            {
                x.TaskId,
                x.UserId
            });

            builder.HasOne(x => x.Task)
                .WithMany(x => x.TaskMembers)
                .HasForeignKey(x => x.TaskId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.User)
                .WithMany(x => x.TaskMembers)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}