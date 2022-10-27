using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMSystem.Model.Dto
{
    public class Page_Reply_Resources
    {

        public int total { get; set; }

        public List<Reply_ResourcesDto> date { get; set; } = new List<Reply_ResourcesDto>();
    }
}
