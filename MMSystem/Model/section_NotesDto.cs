using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMSystem.Model
{
    public class section_NotesDto
    {
        public int ID { get; set; }  
        public int send_ToId { get; set; }

        public string department_name { get; set; }

        public string Note { get; set; }
        public bool State { get; set; }
      

    }
}
