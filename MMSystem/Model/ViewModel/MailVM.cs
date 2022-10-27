using MMSystem.Model.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMSystem.Model.ViewModel
{
    public class MailVM
    {
        public MailDto mail { get; set; }


        public List<ActionSender> actionSenders  { get; set; }

        public List<Mail_ResourcescsDto> resourcescs { get; set; }

        public List<Department> departments { get; set; } = new List<Department> { };

        public int total { get; set; }

        public MailVM()
        {
            actionSenders = new List<ActionSender>() { };
        }
    }
}
