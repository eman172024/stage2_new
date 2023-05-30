using MMSystem.Model.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MMSystem.Model.ViewModel
{
    public class Sended_Maill
    {

        public bool exdep_state { get; set; }
        public int side_number { get; set; }

        public int dep_fil { get; set; }

        public int entity_refernceNum { get; set; }
        public int replay_To { get; set; }
        public bool replay_isSend { get; set; }
        public bool replay_State { get; set; }
        public int external_sectionid { get; set; }
        public int externalInbox_sectionid { get; set; }


        public int mail_id { get; set; }
        public int to_rep { get; set; }
        public int mailid { get; set; }
        public int action { get; set; }
        public string action_required_by_the_entity { get; set; }

        public int attashment { get; set; }
        public string delvirey { get; set; }
        public string note { get; set; }


        public int Mail_Number { get; set; }
        public int clasfiction { get; set; }
        public int genralinboxnumber { get; set; }

        public DateTime date { get; set; }
        public DateTime DateOfMail { get; set; }
        public DateTime date2 { get; set; }

        public DateTime Insert_date { get; set; }

        public String Masure_type { get; set; }

        public string mangment_sender { get; set; }
        public bool is_multi { get; set; }

        public bool mail_state { get; set; }


        public int mangment_sender_id { get; set; }

        public int type_of_mail { get; set; }

        public int flag { get; set; }
        public string Send_time { get; set; }

        public string time { get; set; }

        public string State { get; set; }

        public string summary { get; set; }
        public DateTime update { get; set; }

        public int Sends_id { get; set; }
        public int SectionId { get; set; }

        public int typeofsend { get; set; }

        public int tomangment { get; set; }
        public int measure_id { get; set; }

        public bool sends_state { get; set; }

        public DateTime update_At { get; set; }

        public string action_require { get; set; }
        public string sectionname { get; set; }


    }
}
