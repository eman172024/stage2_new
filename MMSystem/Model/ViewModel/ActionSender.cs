using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMSystem.Model.ViewModel
{
    public class ActionSender
    {
        public int departmentId { get; set; }
        public string departmentName { get; set; }
        public int measureId { get; set; }
        public string measureName { get; set; }

        public int send_ToId { get; set; }



        public int flag { get; set; }
    }
}
