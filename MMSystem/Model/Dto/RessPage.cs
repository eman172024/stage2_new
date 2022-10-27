using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMSystem.Model.Dto
{
    public class RessPage
    {

        public int total { get; set; }

        //List<Mail_ResourcescsDto> mail_ResourcescsDtos = new List<Mail_ResourcescsDto>();
       public List<Mail_ResourcescsDto> data { get; set; } = new List<Mail_ResourcescsDto>() { };

      //  public Mail_ResourcescsDto data1 { get; set; } = new Mail_ResourcescsDto() {};



    }
}
