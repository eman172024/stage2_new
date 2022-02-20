using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MMSystem.Model
{
    public class External_Mail
    {
        [Key]
        public int ID { get; set; }

        public int MailID { get; set; }

           [JsonIgnore]
        public Mail Mail { get; set; }

        public Extrmal_Section Section { get; set; }

        public int action { get; set; }

        public int Sectionid { get; set; }

        public int SectorId { get; set; }

        public int SectorType { get; set; }

        public string action_required_by_the_entity { get; set; }
        //for 
        public DateTime Send_of_Ex_mail  { get; set; }


        public string delivery { get; set; }
        public string note { get; set; }

        public int number_of_copies{ get; set; }
        public bool Attachments { get; set; }

    }
}
