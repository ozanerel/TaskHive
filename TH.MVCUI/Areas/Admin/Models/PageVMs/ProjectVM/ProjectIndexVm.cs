using TH.ENTITIES.Enums;
using TH.ENTITIES.Models;

namespace TH.MVCUI.Areas.Admin.Models.PageVMs.ProjectVM
{
    public class ProjectIndexVm
    {
        public List<Project> Projects { get; set; } = new();

        public string Search { get; set; }//Project Name/Description

        public DataStatus? Status { get; set; }//Active/Passive

        public string SortBy { get; set; }//Name/Date/Task Count
    }
}