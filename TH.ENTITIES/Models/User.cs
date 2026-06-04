using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TH.ENTITIES.Models
{
    public class User:BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public int RoleId { get; set; }

        //Relational Properties
        //1 User can have many Projects,Tasks
        public virtual ICollection<Project> Projects { get; set; }
        public virtual ICollection<Task> Tasks { get; set; }
        public virtual ICollection<Notification> Notifications { get; set; }
        public virtual ICollection<TaskComment> TaskComments { get; set; }
        public virtual Role Role { get; set; }
    }
}
