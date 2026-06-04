using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TH.ENTITIES.Models
{
    public class TaskComment:BaseEntity
    {
        public string Message { get; set; }
        public bool IsRead { get; set; }

        public int TaskId { get; set; }
        public int UserId { get; set; }

        //Relational Properties
        public virtual Task Task { get; set; }
        public virtual User User { get; set; }
    }
}
