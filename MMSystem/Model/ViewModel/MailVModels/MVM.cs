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

        public MailDto mail { get; set; }
        public List<Mail_ResourcescsDto> mail_Resourcescs { get; set; } = new List<Mail_ResourcescsDto> (){ };

        public List<RViewModel> list { get; set; } = new List<RViewModel> (){ };




    }
}
