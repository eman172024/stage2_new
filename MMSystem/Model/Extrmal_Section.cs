﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MMSystem.Model
{
    public class Extrmal_Section
    {
        [Key]
        public int id { get; set; }
        public string Section_Name{ get; set; }
        //
        public int number_of_mail { get; set; }
        public int perent { get; set; }

     public List<Extrenal_inbox> Extrenal_Inboxes { get; set; }
        public List<External_Mail> External_Mails { get; set; }

    }
}
