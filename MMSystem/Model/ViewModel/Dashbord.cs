using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMSystem.Model.ViewModel
{
    public class Dashbord
    {
        public int TotaleSender { get; set; }
        public int TotaleReceived { get; set; }
        public int TotaleExpord { get; set; }

        public int Totale_Internal { get; set; }
        public int not_sended { get; set; }

        public int Not_response_to_me { get; set; }

        public int incoming { get; set; }

        public int Not_response_from_you { get; set; }




        public int extirnel { get; set; }
        public int not_sended_externl { get; set; }

        public int Not_response_to_me_external { get; set; }

        public int incoming_externil { get; set; }

        public int Not_response_from_you_externil { get; set; }




        public int extirnelInbox { get; set; }
        public int not_sended_externlInbox { get; set; }

        public int Not_response_to_me_externlInbox { get; set; }

        public int incoming_externilInbox { get; set; }

        public int Not_response_from_you_extrinlInbox { get; set; }
    }
}
