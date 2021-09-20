using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMSystem.Model.Dto
{
    public class Reply_ResourcesDto
    {
        public int ID { get; set; }
        public int ReplyId { get; set; }
       
        public string path { get; set; }
        public int order { get; set; }

    }
}
