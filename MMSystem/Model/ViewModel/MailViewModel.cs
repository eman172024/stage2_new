using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MMSystem.Model.ViewModel
{
    public class MailViewModel
    {
        public int userId { get; set; }

        public Mail mail { get; set; }
    
        public External_Mail external_Mail { get; set; }
        public Extrenal_inbox extrenal_Inbox { get; set; }
        public List<ActionSender> actionSenders { get; set; }

        public List<ActionSender> newactionSenders { get; set; }

        public List<External_Department> external_sectoin { get; set; }



    }
}
