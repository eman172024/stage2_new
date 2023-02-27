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

        public List<Mail_ResourcescsDto> resourcescs { get; set; }
        public List<ActionSender> actionSenders { get; set; }
        public List<Ex_Departments> external_sectoin { get; set; } = new List<Ex_Departments>();


        public List<Extrmal_Section> side { get; set; }
        public List<Extrmal_Section> sector { get; set; }
        public List<Department> departments { get; set; } = new List<Department> { };

        public int total { get; set; }


        public ExInbox()
        {
            actionSenders = new List<ActionSender>();
            resourcescs = new List<Mail_ResourcescsDto>() { };
            side = new List<Extrmal_Section>() { };
            sector = new List<Extrmal_Section>() { };



        }

    }
}
