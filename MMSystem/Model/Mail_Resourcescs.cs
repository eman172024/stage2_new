using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MMSystem.Model
{
    public class Mail_Resourcescs
    {

        [Key]
        public int ID { get; set; }
        public int MailID { get; set; }
        public Mail Mail { get; set; }
        public string path { get; set; }

        public int order { get; set; }
        public bool State { get; set; }


    }
}
