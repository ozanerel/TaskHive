using System;

namespace TH.MVCUI.Areas.Member.Models.PageVMs.ChatVM
{
    public class ConversationListVm
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string LastMessageContent { get; set; }

        public DateTime? LastMessageDate { get; set; }

        public int UnreadMessageCount { get; set; }

        public bool IsTeamConversation { get; set; }
    }
}
