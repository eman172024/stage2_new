using MMSystem.Model.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMSystem.Model.ViewModel.MailVModels
{
    public class EMVM
    {
        public MailDto mail { get; set; }

        public ExternalDto External { get; set; }
        public List<Mail_ResourcescsDto> mail_Resourcescs { get; set; } = new List<Mail_ResourcescsDto>() { };

      

        public List<RViewModel> list { get; set; } = new List<RViewModel>() { };

    }
}
