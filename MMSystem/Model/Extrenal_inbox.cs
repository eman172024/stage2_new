using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MMSystem.Model
{
    public class Extrenal_inbox
    {
        [Key]
        public int Id { get; set; }

        public int MailID { get; set; }

        
        public Mail Mail { get; set; }

        public Extrmal_Section Section { get; set; }

        public int action { get; set; }

        public int SectionId { get; set; }

        public string section_Name { get; set; }

        public int to { get; set; }

        public int type { get; set; }

        public int office_type { get; set; }

        public DateTime Send_time { get; set; }

        public int entity_reference_number { get; set; }

        public int procedure_type { get; set; }

    }
}
