using MMSystem.Model.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMSystem.Model.ViewModel
{
    public class Sended_Maill
    {

        public int mail_id { get; set; }
        public int Mail_Number { get; set; }

        public string date { get; set; }

        public int procedure_type { get; set; }

        public string mangment_sender { get; set; }

        public string type_of_mail { get; set; }

        public DateTime Send_time { get; set; }

        public string time { get; set; }

        public string State { get; set; }

        public string summary { get; set; }


       public List<Mail_Resourcescs> mail_res { get; set; }

    }
}
