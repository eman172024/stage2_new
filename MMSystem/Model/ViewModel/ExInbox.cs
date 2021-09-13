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
        public Extrenal_inboxDto external { get; set; }

        public List<Mail_ResourcescsDto> resourcescsDto { get; set; }
        public List<ActionSender> actionSenders { get; set; }


        public List<Extrmal_Section> side { get; set; }
        public List<Extrmal_Section> sector { get; set; }
        public ExInbox()
        {
            actionSenders = new List<ActionSender>();
            resourcescsDto = new List<Mail_ResourcescsDto>() { };
            side = new List<Extrmal_Section>() { };
            sector = new List<Extrmal_Section>() { };



        }

    }
}
