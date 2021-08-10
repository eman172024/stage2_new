using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MMSystem.Model
{
    public class Mail
    {
        [Key]
        public int MailID { get; set; }
        public int Mail_Number { get; set; }
        public int Management_Id { get; set; }
        public int currentYear { get; set; }
        public DateTime Date_Of_Mail { get; set; }
        public string Mail_Summary { get; set; }
        public string classification { get; set; }
       public string  Mail_Type { get; set; }
        public int Genaral_inbox_Number { get; set; }
        public int Genaral_inbox_year { get; set; }
        public string Action_Required { get; set; }
        public int userId { get; set; }

        public Administrator user { get; set; }

        public External_Mail external_Mail { get; set; }
        public Extrenal_inbox extrenal_Inbox { get; set; }
        public bool state { get; set; }




    }
}
