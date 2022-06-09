using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMSystem.Model.ViewModel
{
    public class Dashbord
    {


        //مجموع الصادر الداخلي
        public int Totale_internell_externl { get; set; }

        //مجموع الصادر الداخلي التي لم تقرائ 
        public int Notreaded_internell_externl { get; set; }

        //مجموع الصادر الخارجي
        public int Totale_externl { get; set; }

        //مجموع الصادر الخارجي التي لم تقرائ 
        public int Notreaded_Totale_externl { get; set; }

        //مجموع الوارد الخارجي
        public int Totale_inbox { get; set; }

        //مجموع الصادر الوارد التي لم تقرائ 
        public int Notreaded_Totale_inbox { get; set; }




        //مجموع الوارد الداخلي
        public int Totale_Internal_inbox { get; set; }

        //مجموع الوارد الداخلي التي لم تقرائ 
        public int Notreaded_Totale_Internal_inbox { get; set; }

        //مجموع الوارد  الصادرالخارجي
        public int Total_externl2 { get; set; }

        //مجموع الوارد الصادر الخارجي التي لم تقرائ 
        public int Notreaded_Total_externl2 { get; set; }

        //مجموع الوارد الوارد الخارجي
        public int Totale_inbox2 { get; set; }

        //مجموع الوارد الوارد الخارجي التي لم تقرائ 
        public int Notreaded_Totale_inbox2 { get; set; }


    }
}
