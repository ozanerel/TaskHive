using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TH.ENTITIES.Models
{
    public class TeamMember : BaseEntity
    {
        public int TeamId { get; set; }

        public int UserId { get; set; }

        // Relational Properties

        public virtual Team Team { get; set; }

        public virtual User User { get; set; }
    }
}