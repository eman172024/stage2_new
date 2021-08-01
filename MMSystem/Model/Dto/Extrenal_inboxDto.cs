using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMSystem.Model.Dto
{
    public class Extrenal_inboxDto
    {
       
        public int Id { get; set; }



        public int to { get; set; }
        public string type { get; set; }
        public DateTime Send_time { get; set; }



        public int MailID { get; set; }
      
        public int SectionId { get; set; }
      
        public string section_Name { get; set; }

        public string action_Requierd { get; set; }


    }
}
