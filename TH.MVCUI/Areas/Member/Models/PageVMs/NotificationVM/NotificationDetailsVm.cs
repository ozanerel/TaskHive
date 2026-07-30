using TH.ENTITIES.Models;

namespace TH.MVCUI.Areas.Member.Models.PageVMs.NotificationVM
{
    public class NotificationDetailsVm
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Message { get; set; }

        public DateTime NotificationDate { get; set; }

        public bool IsRead { get; set; }

        public User? User { get; set; }
    }
}