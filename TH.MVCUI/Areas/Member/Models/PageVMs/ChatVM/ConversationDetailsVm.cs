using System.Collections.Generic;

namespace TH.MVCUI.Areas.Member.Models.PageVMs.ChatVM
{
    public class ConversationDetailsVm
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public bool IsTeamConversation { get; set; }

        public int? TeamId { get; set; }

        public List<MessageListVm> Messages { get; set; }
            = new List<MessageListVm>();

        public SendMessageVm SendMessage { get; set; }
            = new SendMessageVm();
    }
}
