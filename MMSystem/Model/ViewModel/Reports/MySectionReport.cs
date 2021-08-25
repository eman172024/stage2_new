using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMSystem.Model.ViewModel
{
    public class MySectionReport
    {
        public string DepartmentName { get; set; }
        public int TotalOfReceived { get; set; }
        public int Replay { get; set; }
        public int NotReplay { get; set; }
    }
}
