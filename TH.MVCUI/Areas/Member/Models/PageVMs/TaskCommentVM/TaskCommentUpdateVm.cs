using System.ComponentModel.DataAnnotations;

namespace TH.MVCUI.Areas.Member.Models.PageVMs.TaskCommentVM
{
    public class TaskCommentUpdateVm
    {
        public int Id { get; set; }

        [Required]
        public string Message { get; set; }

        //public bool IsRead { get; set; }

        //public int TaskId { get; set; }

        //public int UserId { get; set; }
    }
}