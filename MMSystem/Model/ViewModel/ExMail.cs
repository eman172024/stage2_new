﻿using MMSystem.Model.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMSystem.Model.ViewModel
{
    public class ExMail
    {
        public MailDto mail { get; set; }

        public ExternalDto External { get; set; }
        public List<Mail_ResourcescsDto> resourcescsDto { get; set; }
        public List<ActionSender> actionSenders { get; set; }
        public List<Extrmal_Section> list { get; set; }
   
        public ExMail()
        {
            actionSenders = new List<ActionSender>() { };
            list = new List<Extrmal_Section>() { };
        }

    }
}
