using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMSystem.Model.Dto
{
    public class ReplayDto
    {
        public int ReplyId { get; set; }
     
        public int send_ToId { get; set; }
   
        public string mail_detail { get; set; }
        public string Date { get; set; }
        public int To { get; set; }
        public bool state { get; set; }
        public int UserId { get; set; }


    }
}
