using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TH.ENTITIES.Models
{
    public class Team : BaseEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        // Relational Properties

        public virtual ICollection<TeamMember> TeamMembers { get; set; }

        public virtual ICollection<Project> Projects { get; set; }
    }
}