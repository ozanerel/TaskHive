using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TH.ENTITIES.Models;

namespace TH.CONF.Options
{
    public class ConversationConfiguration : BaseConfiguration<Conversation>
    {
        public override void Configure(EntityTypeBuilder<Conversation> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Type)
                   .IsRequired();

            builder.Property(x => x.TeamId)
                   .IsRequired(false);

            // Conversation -> Team
            // Private Chat'te TeamId null olabilir.
            // Team silinse bile Conversation otomatik silinmesin.
            builder.HasOne(x => x.Team)
                   .WithMany()
                   .HasForeignKey(x => x.TeamId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Conversation -> Messages
            builder.HasMany(x => x.Messages)
                   .WithOne(x => x.Conversation)
                   .HasForeignKey(x => x.ConversationId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Conversation -> Participants
            builder.HasMany(x => x.Participants)
                   .WithOne(x => x.Conversation)
                   .HasForeignKey(x => x.ConversationId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}