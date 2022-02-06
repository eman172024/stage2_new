using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMSystem.Model
{
    public class LoginHistory
    {
        public int ID { get; set; }
        public int UserId { get; set; }
        public DateTime Time_of_login { get; set; }
        public DateTime Time_of_logout { get; set; }
        public string Hour_of_work { get; set; }

    }
}
