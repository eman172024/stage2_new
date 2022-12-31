using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMSystem.Model.Dto
{
    public class MailDto
    {
        public int MailID { get; set; }
        public int Mail_Number { get; set; }
        public int department_Id { get; set; }
        public string Date_Of_Mail { get; set; }
        public string Mail_Summary { get; set; }
        public string clasification { get; set; }
        public int Mail_Type { get; set; }
        public int Genaral_inbox_Number { get; set; }
        public int Genaral_inbox_year { get; set; }
        public string Action_Required { get; set; }
        public int userId { get; set; }
        public bool is_send { get; set; }
        public int mail_year { get; set; }

        public string classification_name { get; set; }

        public int flag { get; set; }

        public string old_mail_number { get; set; }
        public string office_type { get; set; }



    }
}
