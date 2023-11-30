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

        public int Department_Id { get; set; }
        public DateTime Date_Of_Mail { get; set; }
        public string Mail_Summary { get; set; }
        //
        public int clasification { get; set; }
    // public string  Mail_Type { get; set; }
        public int Mail_Type { get; set; }
        public int Genaral_inbox_Number { get; set; }
        public int Genaral_inbox_year { get; set; }
        public int userId { get; set; }

        public string ActionRequired { get; set; }

        public bool is_send { get; set; }
        public Administrator user { get; set; }
        public DateTime insert_at { get; set; }
        public External_Mail external_Mail { get; set; }
        public Extrenal_inbox extrenal_Inbox { get; set; }
        public bool state { get; set; }

        public string old_mail_number { get; set; }
        public bool Under_the_procedure { get; set; }


        public string conclusion { get; set; }
        public string office_type { get; set; }
    
        public List<External_Department> external_Departments { get; set; }
        public List<Mail_Resourcescs> mail_Resourcescs { get; set; }



    }
}
