using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MMSystem.Model.ViewModel
{
    public class Uplode
    {[Required]


        public int userId { get; set; }
        public int mail_id { get; set; }
        public List<UplodeFile> list { get; set; }

    }
}
