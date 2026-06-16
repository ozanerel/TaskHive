using TH.ENTITIES.Models;

namespace TH.MVCUI.Models.ViewModels.PageVMs
{
    public class NotificationPageVm
    {
        public Notification Notification { get; set; }

        public List<Notification> Notifications { get; set; }

        public List<User> Users { get; set; }
    }
}
