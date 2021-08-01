using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMSystem.Model.Dto
{
    public class ExternalDto
    {
        public int ID { get; set; }





        public int MailID { get; set; }
        public Mail Mail { get; set; }
        public int Sectionid { get; set; }
       
        public string sectionName { get; set; }
        public string action_Requierd { get; set; }
    }
}
