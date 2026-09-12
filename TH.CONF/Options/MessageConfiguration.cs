using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TH.ENTITIES.Models;

namespace TH.CONF.Options
{
    public class MessageConfiguration : BaseConfiguration<Message>
    {
        public override void Configure(EntityTypeBuilder<Message> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Content)
                   .IsRequired()
                   .HasMaxLength(2000);

            builder.Property(x => x.ConversationId)
                   .IsRequired();

            builder.Property(x => x.UserId)
                   .IsRequired();

            // Message -> Conversation
            builder.HasOne(x => x.Conversation)
                   .WithMany(x => x.Messages)
                   .HasForeignKey(x => x.ConversationId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Message -> User
            // User entity'sinde Messages collection'ı bulunmadığı için
            // WithMany() kullanıyoruz.
            builder.HasOne(x => x.User)
                   .WithMany()
                   .HasForeignKey(x => x.UserId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}