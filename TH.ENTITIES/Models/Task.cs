using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TH.ENTITIES.Enums;

namespace TH.ENTITIES.Models
{
    public class Task:BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public PriorityLevel Priority { get; set; }
        public bool IsCompleted { get; set; }

        //Görevin son teslim tarihi
        public DateTime? DueDate { get; set; }
        //Görevin tamamlanma tarihi
        public DateTime? CompletedDate { get; set; }

        public int UserId { get; set; }
        public int ProjectId { get; set; }


        //Relational Properties
        public virtual User User { get; set; }
        public virtual Project Project { get; set; }
        public virtual ICollection<TaskComment> TaskComments { get; set; }
    }
}
