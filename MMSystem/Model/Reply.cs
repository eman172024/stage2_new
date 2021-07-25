using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MMSystem.Model
{
    public class Reply
    {[Key]
        public int ReplyId { get; set; }
       

        public Send_to send_To { get; set; }
        public string mail_detail { get; set; }
        public DateTime Date { get; set; }
        public int To { get; set; }
        public bool state { get; set; }
        public List<Reply_Resources> MyProperty { get; set; }

    }
}
