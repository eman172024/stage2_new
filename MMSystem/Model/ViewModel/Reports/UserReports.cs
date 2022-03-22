using System.Collections.Generic;


namespace MMSystem.Model.ViewModel.Reports
{
    public class UserReports
    {
        public string UserName { get; set; }

        public List<UserMailInfo> information1 { get; set; } = new List<UserMailInfo>();
     
    }
}
