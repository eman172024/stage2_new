using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMSystem.Model.ViewModel.Reports
{
    public class Report_details_view_model
    {

        public string department_name { get; set; }


        public Report_View_Model data { get; set; } =new  Report_View_Model();
       
    }
}
