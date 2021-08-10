using MMSystem.Model.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMSystem.Model.ViewModel
{
    public class ExInbox
    {

        public MailDto mail { get; set; }
        public Extrenal_inboxDto extrenal { get; set; }

        public List<Mail_ResourcescsDto> resourcescsDto { get; set; }
    }
}
