using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMSystem.Model.ViewModel
{
    public class ExtarnelinboxViewModel
    {
        public int mail_id { get; set; }
        public int Mail_Number { get; set; }
        public int typeofsend { get; set; }
        public bool mail_state { get; set; }
        public int measure_id { get; set; }
        public int clasfiction { get; set; }
        public int tomangment { get; set; }
        public int genralinboxnumber { get; set; }
        public DateTime date { get; set; }

        public bool sends_state { get; set; }
        public DateTime date2 { get; set; }

        public String Masure_type { get; set; }

        public string mangment_sender { get; set; }

        public int mangment_sender_id { get; set; }

        public int flag { get; set; }


        public int type_of_mail { get; set; }

        public string Send_time { get; set; }

        public string time { get; set; }

        public bool is_multi { get; set; }

        public string State { get; set; }

        public string summary { get; set; }

        public string sectionName { get; set; }

        public int Sends_id { get; set; }


        public string actionrequer { get; set; }


    }
}
