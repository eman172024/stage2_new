using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMSystem.Model.Dto
{
    public class Extrenal_inboxDto
    {

        public int Id { get; set; }

        public int MailID { get; set; }


        public int action { get; set; }

        public int SectionId { get; set; }

        public string section_Name { get; set; }

        public int to { get; set; }

        public int type { get; set; }

        public string Send_time { get; set; }

        public int entity_reference_number { get; set; }

        public int procedure_type { get; set; }

        public int office_type { get; set; }


    }
}
