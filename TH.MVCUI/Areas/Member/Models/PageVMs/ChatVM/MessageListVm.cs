using System;

namespace TH.MVCUI.Areas.Member.Models.PageVMs.ChatVM
{
    public class MessageListVm
    {
        public int Id { get; set; }

        public int ConversationId { get; set; }

        public int UserId { get; set; }

        public string UserName { get; set; }

        public string Content { get; set; }

        public DateTime CreatedDate { get; set; }

        public bool IsMine { get; set; }
    }
}
