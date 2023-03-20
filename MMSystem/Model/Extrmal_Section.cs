using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MMSystem.Model
{
    public class Extrmal_Section
    {
        [Key]
        public int id { get; set; }
        public string Section_Name{ get; set; }
        //
        public int perent { get; set; }
        public bool state { get; set; }
        public int type { get; set; }

       
        [JsonIgnore]
        public List<Extrenal_inbox> Extrenal_Inboxes { get; set; }
        [JsonIgnore]
        public List<External_Mail> External_Mails { get; set; }

        public List<External_Department> departments { get; set; }



    }
}
