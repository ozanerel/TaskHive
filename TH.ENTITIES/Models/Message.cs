using System;

namespace TH.ENTITIES.Models
{
    public class Message : BaseEntity
    {
        public string Content { get; set; }

        public int ConversationId { get; set; }

        public int UserId { get; set; }

        // Relational Properties

        public virtual Conversation Conversation { get; set; }

        public virtual User User { get; set; }
    }
}