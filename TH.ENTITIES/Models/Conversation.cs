using System;
using System.Collections.Generic;
using TH.ENTITIES.Enums;

namespace TH.ENTITIES.Models
{
    public class Conversation : BaseEntity
    {
        public ConversationType Type { get; set; }

        // Team Chat için kullanılır.
        // Private Chat'te null kalır.
        public int? TeamId { get; set; }

        // Relational Properties

        public virtual Team? Team { get; set; }

        public virtual ICollection<Message> Messages { get; set; }
            = new List<Message>();

        public virtual ICollection<ConversationParticipant> Participants { get; set; }
            = new List<ConversationParticipant>();
    }
}