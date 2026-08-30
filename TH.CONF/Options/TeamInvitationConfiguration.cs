using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TH.ENTITIES.Models;

namespace TH.CONF.Options
{
    public class TeamInvitationConfiguration : BaseConfiguration<TeamInvitation>
    {
        public override void Configure(EntityTypeBuilder<TeamInvitation> builder)
        {
            base.Configure(builder);

            builder.HasOne(x => x.Team)
                .WithMany()
                .HasForeignKey(x => x.TeamId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.InvitedUser)
                .WithMany()
                .HasForeignKey(x => x.InvitedUserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.InvitedByUser)
                .WithMany()
                .HasForeignKey(x => x.InvitedByUserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(x => x.InvitationStatus)
                .IsRequired()
                .HasConversion<int>();

            builder.HasIndex(x => new
            {
                x.TeamId,
                x.InvitedUserId
            });
        }
    }
}