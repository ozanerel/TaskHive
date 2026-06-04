using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TH.ENTITIES.Models
{
    public class Role: BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public int UserId { get; set; }
        public int ProjectId { get; set; }

        //Relational Properties
        public virtual User User { get; set; }
        public virtual Project Project { get; set; }
    }
}
