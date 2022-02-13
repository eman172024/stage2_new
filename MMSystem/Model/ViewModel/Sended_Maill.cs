using MMSystem.Model.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MMSystem.Model.ViewModel
{
    public class Sended_Maill
    {



        public int mail_id { get; set; }
        public int Mail_Number { get; set; }

        public string date { get; set; }

        public String Masure_type { get; set; }

        public string mangment_sender { get; set; }

        public int mangment_sender_id { get; set; }

        public int type_of_mail { get; set; }

        public int flag { get; set; }
        public string Send_time { get; set; }

        public string time { get; set; }

        public string State { get; set; }

        public string summary { get; set; }

        public int Sends_id { get; set; }


        public string action_require { get; set; }


    }
}
