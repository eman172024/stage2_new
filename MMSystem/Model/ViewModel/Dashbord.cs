using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMSystem.Model.ViewModel
{
    public class Dashbord
    {


        //الصادر الداخلي
        public int Totale_Internal { get; set; }

       // لم يتم ارساله البريد الداخلي 
        public int not_sended { get; set; }
        // لم يتم الرد عليك الداخلي
        public int Not_response_to_me { get; set; }
        // الوارد الداخلي
        public int incoming { get; set; }
        // لم يتم الرد من قيلك
        public int Not_response_from_you { get; set; }

        // الصادر الخارجي
        public int extirnel { get; set; }

        // لم يتم ارساله البريد الصادر الخارجي 
        public int not_sended_externl { get; set; }

        // لم يتم الرد عليك الصادر الخارجي
        public int Not_response_to_me_external { get; set; }

        // الوارد الصادر الخارجي
        public int incoming_externil { get; set; }

        // لم يتم الرد من قيلك
        public int Not_response_from_you_externil { get; set; }



        // صادر الوارد الخارجي

        public int extirnelInbox { get; set; }

        // لم يتم ارساله البريد الوارد الخارجي 
        public int not_sended_externlInbox { get; set; }
        // لم يتم الرد عليك الصادر الخارجي

        public int Not_response_to_me_externlInbox { get; set; }
        // الوارد الوارد الخارجي

        public int incoming_externilInbox { get; set; }


        //   الوارد الخارجي  لم يتم الرد من قيلك

        public int Not_response_from_you_extrinlInbox { get; set; }
    }
}
