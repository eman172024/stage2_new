using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MMSystem.Model
{
    public class Reply
    {[Key]
        public int ReplyId { get; set; }
        [ForeignKey("send_ToId")]
        public int send_ToId { get; set; }
        public Send_to send_To { get; set; }
        public string mail_detail { get; set; }
        public DateTime Date { get; set; }
        public int To { get; set; }
        public bool state { get; set; }
        public int UserId { get; set; }
        public bool IsSend { get; set; }
        public List<Reply_Resources> _Resources { get; set; }

    }
}
