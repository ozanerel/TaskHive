using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TH.ENTITIES.Models
{
    public class Project:BaseEntity
    {
        public string ProjectName { get; set; }
        public string Description { get; set; }


        //Relational Properties
        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<Role> Roles { get; set; }
        public virtual ICollection<Task> Tasks { get; set; }
    }
}
