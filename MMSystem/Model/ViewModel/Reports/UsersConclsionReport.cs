using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMSystem.Model.ViewModel.Reports
{
    public class UsersConclsionReport
    {
    
        public string UserName { get; set; }

        //public DateTime Last_date { get; set; }
        public TotalCounts Total_Count { get; set; } = new TotalCounts() { };
    }
}
