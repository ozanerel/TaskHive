using TH.ENTITIES.Enums;

namespace TH.MVCUI.Areas.Member.Models.PageVMs.TaskVM
{
    public class MyTaskUpdateVm
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public PriorityLevel Priority { get; set; }
    }
}