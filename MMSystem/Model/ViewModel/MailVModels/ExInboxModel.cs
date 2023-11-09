using MMSystem.Model.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMSystem.Model.ViewModel.MailVModels
{
    public class ExInboxModel
    {
        public MailDto mail { get; set; }

        public Extrenal_inboxDto Inbox { get; set; }

        public Extrmal_Section side { get; set; }
        public Extrmal_Section Sector { get; set; }
        public List<Mail_ResourcescsDto> mail_Resourcescs { get; set; } = new List<Mail_ResourcescsDto>() { };
        public List<Ex_Departments> external_sectoin { get; set; }

       public List<ReplayModel> list { get; set; } = new List<ReplayModel>() { };

        public List<section_NotesDto> section_Notes { get; set; } = new List<section_NotesDto>() { };

        public List<Mail_ResourcescsDto> mail_Resources_resended { get; set; } = new List<Mail_ResourcescsDto>() { };


    }
}
