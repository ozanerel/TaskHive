using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TH.ENTITIES.Models;

namespace TH.CONF.Options
{
    public class ConversationParticipantConfiguration
        : BaseConfiguration<ConversationParticipant>
    {
        public override void Configure(
            EntityTypeBuilder<ConversationParticipant> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.ConversationId)
                   .IsRequired();

            builder.Property(x => x.UserId)
                   .IsRequired();

            builder.Property(x => x.LastReadMessageId)
                   .IsRequired(false);

            // ConversationParticipant -> Conversation
            builder.HasOne(x => x.Conversation)
                   .WithMany(x => x.Participants)
                   .HasForeignKey(x => x.ConversationId)
                   .OnDelete(DeleteBehavior.Restrict);

            // ConversationParticipant -> User
            builder.HasOne(x => x.User)
                   .WithMany()
                   .HasForeignKey(x => x.UserId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Aynı kullanıcı aynı konuşmaya iki kez eklenemesin.
            builder.HasIndex(x => new
            {
                x.ConversationId,
                x.UserId
            })
            .IsUnique();
        }
    }
}