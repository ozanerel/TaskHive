using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TH.ENTITIES.Models
{
    public class TaskMember
    {
        public int TaskId { get; set; }
        public int UserId { get; set; }

        public virtual Task Task { get; set; }
        public virtual User User { get; set; }
    }
}
