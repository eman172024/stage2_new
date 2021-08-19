using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMSystem.Model.ViewModel
{
    public class MailViewModel
    {
        public Mail mail { get; set; }

        public External_Mail external_Mail { get; set; }
        public Extrenal_inbox extrenal_Inbox { get; set; }
        public List<ActionSender> actionSenders { get; set; }


    }
}
