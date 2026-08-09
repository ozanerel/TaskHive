using TH.ENTITIES.Enums;

namespace TH.MVCUI.Areas.Member.Models.PageVMs.MyProjectVM
{
    public class MyProjectListVm
    {
        public int Id { get; set; }

        public string ProjectName { get; set; }

        public string Description { get; set; }

        public int UserCount { get; set; }

        public int TaskCount { get; set; }
        
        public DataStatus Status { get; set; }
    }
}