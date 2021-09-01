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
        public int Management_Id { get; set; }
        public int currentYear { get; set; }
        public string Date_Of_Mail { get; set; }
        public string Mail_Summary { get; set; }
        public string classification { get; set; }
        public string Mail_Type { get; set; }
        public int Genaral_inbox_Number { get; set; }
        public int Genaral_inbox_year { get; set; }
        public string Action_Required { get; set; }
        public int userId { get; set; }



    }
}
