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

        //Relational Properties
        public virtual ICollection<User> Users { get; set; }
    }
}
