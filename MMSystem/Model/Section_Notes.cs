using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MMSystem.Model
{
    public class Section_Notes
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey("send_ToId")]
        public int send_ToId { get; set; }
        public string Note { get; set; }
        public bool State { get; set; }
        public Send_to send_To { get; set; }


    }
}