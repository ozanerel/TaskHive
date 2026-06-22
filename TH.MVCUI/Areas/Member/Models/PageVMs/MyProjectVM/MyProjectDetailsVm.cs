using TH.ENTITIES.Models;

namespace TH.MVCUI.Areas.Member.Models.PageVMs.MyProjectVM
{
    public class MyProjectDetailsVm
    {
        public int Id { get; set; }

        public string ProjectName { get; set; }

        public string Description { get; set; }

        public List<User> Users { get; set; }

        public List<TH.ENTITIES.Models.Task> Tasks { get; set; }
    }
}