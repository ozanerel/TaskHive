using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TH.ENTITIES.Models;

namespace TH.CONF.Options
{
    public class TeamConfiguration : BaseConfiguration<Team>
    {
        public override void Configure(EntityTypeBuilder<Team> builder)
        {
            base.Configure(builder);

            builder.Property(t => t.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(t => t.Description)
                   .IsRequired()
                   .HasMaxLength(250);

            builder.HasMany(t => t.TeamMembers)
                   .WithOne(tm => tm.Team)
                   .HasForeignKey(tm => tm.TeamId)
                   .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);

            //builder.HasMany(t => t.Projects)
            //       .WithOne()
            //       .HasForeignKey("TeamId")
            //       .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);
        }
    }
}