using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TH.DAL.ContextClasses;
using TH.DAL.Repositories.Abstracts;
using TH.ENTITIES.Models;

namespace TH.DAL.Repositories.Concretes
{
    public class TaskCommentRepository:BaseRepository<TaskComment>, ITaskCommentRepository
    {
        public TaskCommentRepository(MyContext context):base(context)
        {
            
        }
    }
}
