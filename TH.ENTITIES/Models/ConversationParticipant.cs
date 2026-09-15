using System;

namespace TH.ENTITIES.Models
{
    public class ConversationParticipant : BaseEntity
    {
        public int ConversationId { get; set; }

        public int UserId { get; set; }

        // Kullanıcının bu konuşmada en son okuduğu mesajın ID'si.
        // Null olması, kullanıcının henüz hiçbir mesaj okumadığını ifade eder.
        public int? LastReadMessageId { get; set; }

        // Relational Properties

        public virtual Conversation Conversation { get; set; }

        public virtual User User { get; set; }
    }
}