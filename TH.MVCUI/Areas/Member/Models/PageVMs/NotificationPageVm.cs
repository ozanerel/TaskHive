using TH.ENTITIES.Models;

namespace TH.MVCUI.Areas.Member.Models.PageVMs
{
    public class NotificationPageVm
    {
        public Notification Notification { get; set; }

        public List<Notification> Notifications { get; set; }

        public List<User> Users { get; set; }
    }
}
