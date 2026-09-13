using System.ComponentModel.DataAnnotations;

namespace TH.MVCUI.Areas.Member.Models.PageVMs.ChatVM
{
    public class SendMessageVm
    {
        [Required(
            ErrorMessage = "Mesaj içeriği boş bırakılamaz.")]
        [StringLength(
            2000,
            ErrorMessage = "Mesaj en fazla 2000 karakter olabilir.")]
        public string Content { get; set; }

        public int ConversationId { get; set; }
    }
}
