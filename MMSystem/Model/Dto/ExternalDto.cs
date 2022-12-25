using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MMSystem.Model.Dto
{
    public class ExternalDto
    {
        public int ID { get; set; }

        public int MailID { get; set; }

     
        public int action { get; set; }

        public int Sectionid { get; set; }

        public string sectionName { get; set; }

        public string action_required_by_the_entity { get; set; }
       
    
       


        public int type { get; set; }


    }
}
