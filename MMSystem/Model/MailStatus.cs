using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MMSystem.Model
{
    //for statues mail
    public class MailStatus
    {
        [Key]
        public int flag { get; set; }
       // public string flag_Name { get; set; }

        public string inbox { get; set; }
        public string sent { get; set; }

        public bool state { get; set; }

    }
}
