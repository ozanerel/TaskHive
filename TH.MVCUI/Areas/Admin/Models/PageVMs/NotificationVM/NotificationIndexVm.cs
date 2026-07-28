using TH.ENTITIES.Models;

namespace TH.MVCUI.Areas.Admin.Models.PageVMs.NotificationVM
{
    public class NotificationIndexVm
    {
        public List<Notification> Notifications { get; set; } = new();
    }
}