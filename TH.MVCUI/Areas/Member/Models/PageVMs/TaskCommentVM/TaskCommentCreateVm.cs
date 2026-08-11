using System.ComponentModel.DataAnnotations;

namespace TH.MVCUI.Areas.Member.Models.PageVMs.TaskCommentVM
{
    public class TaskCommentCreateVm
    {
        [Required]
        public string Message { get; set; }

        [Required]
        [Range(1, int.MaxValue)]//int zaten default olarak 0 gelir. 0 gelirse hata verir.
        public int TaskId { get; set; }

        //public int UserId { get; set; }
    }
}