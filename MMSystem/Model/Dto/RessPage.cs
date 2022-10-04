using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMSystem.Model.Dto
{
    public class RessPage
    {
        //List<Mail_ResourcescsDto> mail_ResourcescsDtos = new List<Mail_ResourcescsDto>();
        public List<Mail_ResourcescsDto> data = new List<Mail_ResourcescsDto>();
        public int total { get; set; }

    }
}
