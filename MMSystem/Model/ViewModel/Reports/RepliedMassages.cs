using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMSystem.Model.ViewModel.Reports
{
    public class RepliedMassages
    {
        public int Mail_Number { get; set; }
        public string Mail_Summary { get; set; }
        public string Mail_Type { get; set; }
        public DateTime Date_Of_Mail { get; set; }
        public string Action_Required { get; set; }
        public bool State { get; set; }/// <summary>
        /// replied or not replied
        /// </summary>
        public string Mail_detail { get; set; }/// <summary>
        /// الرد معلومات الرد
        /// </summary>
        public string UserName { get; set; }

    }
}
