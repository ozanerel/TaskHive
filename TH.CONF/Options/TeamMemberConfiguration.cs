using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TH.ENTITIES.Models;

namespace TH.CONF.Options
{
    public class TeamMemberConfiguration : BaseConfiguration<TeamMember>
    {
        public override void Configure(EntityTypeBuilder<TeamMember> builder)
        {
            base.Configure(builder);

            builder.HasOne(tm => tm.Team)
                   .WithMany(t => t.TeamMembers)
                   .HasForeignKey(tm => tm.TeamId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(tm => tm.User)
                   .WithMany()
                   .HasForeignKey(tm => tm.UserId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(tm => new
            {
                tm.TeamId,
                tm.UserId
            })
            .IsUnique();//Aynı kullanıcı aynı Team'e iki kere eklenemeyecek
        }
    }
}