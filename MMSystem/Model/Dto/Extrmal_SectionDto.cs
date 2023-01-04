using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMSystem.Model.Dto
{
    public class Extrmal_SectionDto
    {
        public int id { get; set; }
        public string Section_Name { get; set; }
        
        public int perent { get; set; }

        public int type { get; set; }
        public bool state { get; set; }
    }
}
