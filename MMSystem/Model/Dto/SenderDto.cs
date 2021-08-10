using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMSystem.Model.Dto
{
    public class SenderDto
    {
        public int Id { get; set; }

        public int MailID { get; set; }
      

        public int to { get; set; }

        public string type_of_mail { get; set; }

        public DateTime Send_time { get; set; }
        public bool flag { get; set; }

        public bool State { get; set; }

        public DateTime time_of_read { get; set; }


    }
}
