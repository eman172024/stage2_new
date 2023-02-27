using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MMSystem.Model
{
    public class External_Department
    {
        [Key]
        public int id { get; set; }


        public int department_number { get; set; }
        public string department_name { get; set; }

        public int sector_number{ get; set; }

        public string sector_name { get; set; }

        public int Mail_id { get; set; }

        public Mail Mail_ { get; set; }


        public DateTime insert_at { get; set; }
        public DateTime update_at { get; set; }

        public bool state { get; set; }

    }
}
