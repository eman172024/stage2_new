using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MMSystem.Model
{
    public class Reply_Resources
    {
        [Key]
        public int ID { get; set; }
        public int ReplyId { get; set; }
        public Reply Reply { get; set; }
        public string path { get; set; }
        public int order { get; set; }
        public bool State { get; set; }

        public bool IsSend { get; set; }







    }
}
