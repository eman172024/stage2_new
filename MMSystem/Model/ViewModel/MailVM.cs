using MMSystem.Model.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMSystem.Model.ViewModel
{
    public class MailVM
    {
        public MailDto mailDto { get; set; }


        public List<ActionSender> actionSenders { get; set; }

        public MailVM()
        {
            actionSenders = new List<ActionSender>() { };
        }
    }
}
