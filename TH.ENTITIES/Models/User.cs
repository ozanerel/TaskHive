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

        public int ProjectId { get; set; }
        public int TaskId { get; set; }
        public int RoleId { get; set; }

        //Relational Properties
        public virtual Project Project { get; set; }
        public virtual Task Task { get; set; }
        public virtual Role Roles { get; set; }
    }
}
