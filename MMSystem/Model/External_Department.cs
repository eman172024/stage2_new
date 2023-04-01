using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MMSystem.Model
{
    public class External_Department
    {
        [Key]
        public int id { get; set; }
        [ForeignKey("side_")]
        public int side_number { get; set; }

      //  public string side_name { get; set; }


        //  public string sector_name { get; set; }

        public Extrmal_Section side_ { get; set; }
        public int sector_number{ get; set; }


        public int Mail_id { get; set; }

        public Mail Mail_ { get; set; }


        public DateTime insert_at { get; set; }

        public int mail_forwarding { get; set; }

        public bool state { get; set; }

    }
}
