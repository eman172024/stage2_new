using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MMSystem.Model
{
    public class Send_to
    {
        [Key]
        public int Id { get; set; }
        public int MailID { get; set; }
        public Mail Mail { get; set; }
        public int to { get; set; }
        public int type_of_send{ get; set; }
        public DateTime Send_time { get; set; }
        public int flag { get; set; }
     public bool State { get; set; }
        public DateTime time_of_read { get; set; }
        public DateTime update_At { get; set; }
        public List<Reply> replies { get; set; }
        public bool isMulti { get; set; }

    }
}
