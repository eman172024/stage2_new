using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMSystem.Model.Dto
{
    public class DepartmentViewModelDto
    {

        public string  send_to_name { get; set; }
        public  int send_to { get; set; }
        public int Mail_Number { get; set; }

        public string Mail_Summary { get; set; }

        public string dateOfSend { get; set; }

        public string TimeOfSend { get; set; }

        public string mail_state { get; set; }

        //******add code 12/5/2024
        public string section_name { get; set; }
        //*end 12/5/2024
    }
}
