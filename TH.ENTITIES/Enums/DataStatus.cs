using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TH.ENTITIES.Enums
{
    public enum DataStatus
    {
        Inserted = 1,
        Updated = 2,
        Deleted = 3,
    }

    public enum JobStatus
    {
        NotStarted = 1,
        InProgress = 2,
        Completed = 3,
        Failed = 4
    }

    public enum PriorityLevel
    {
        Low = 1,
        Medium = 2,
        High = 3,
        Critical = 4
    }

    public enum NotificationType
    {
        TaskAssigned = 1,

        TaskCompleted = 2,

        ProjectCreated = 3,

        CommentAdded = 4
    }


}
