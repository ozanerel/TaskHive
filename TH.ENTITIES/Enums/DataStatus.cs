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

        CommentAdded = 4,

        Welcome = 5,

        ProjectUpdated = 6,

        TaskUpdated = 7,

        TaskDeleted = 8,

        UserCreated = 9,

        ProjectDeleted = 10,

        UserUpdated = 11,

        UserDeleted = 12
    }

    public enum TeamRole
    {
        //Member default olarak gelsin diye 1 yazdık başka türlü bir anlamı veya farkı yok
        Member = 1,
        Admin = 2
    }

    public enum InvitationStatus
    {
        Pending = 1,
        Accepted = 2,
        Rejected = 3
    }

    public enum ConversationType
    {
        Private = 1,
        Team = 2
    }

}
