using MMSystem.Model.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMSystem.Model.ViewModel.MailVModels
{
    //view model for intrnal mail
    public class MVM
    {
        public bool is_resended { get; set; }

        public int resended_from { get; set; }

        public MailDto mail { get; set; }
        public List<Mail_ResourcescsDto> mail_Resourcescs { get; set; } = new List<Mail_ResourcescsDto> (){ };

        public List<RViewModel> list { get; set; } = new List<RViewModel> (){ };

        public List<section_NotesDto> section_Notes { get; set; } = new List<section_NotesDto>() { };

        public List<Mail_ResourcescsDto> mail_Resources_resended { get; set; } = new List<Mail_ResourcescsDto>() { };

        
    }
}
