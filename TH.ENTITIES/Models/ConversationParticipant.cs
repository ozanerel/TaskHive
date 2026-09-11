using System;

namespace TH.ENTITIES.Models
{
    public class ConversationParticipant : BaseEntity
    {
        public int ConversationId { get; set; }

        public int UserId { get; set; }

        // Relational Properties

        public virtual Conversation Conversation { get; set; }

        public virtual User User { get; set; }
    }
}