using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMSystem.Model.ViewModel.Reports
{
    public class UserReports
    {
        public string UserName { get; set; }

        public List<UserMailInfo> information1 { get; set; } = new List<UserMailInfo>();
      //  public TotalCounts Total_Count { get; set; }
    }
}
