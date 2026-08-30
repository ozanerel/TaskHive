using System;
using TH.ENTITIES.Enums;

namespace TH.ENTITIES.Models
{
    public class TeamInvitation : BaseEntity
    {
        public int TeamId { get; set; }

        public int InvitedUserId { get; set; }

        public int InvitedByUserId { get; set; }

        public InvitationStatus InvitationStatus { get; set; }

        // Relational Properties

        public virtual Team Team { get; set; }

        public virtual User InvitedUser { get; set; }

        public virtual User InvitedByUser { get; set; }
    }
}