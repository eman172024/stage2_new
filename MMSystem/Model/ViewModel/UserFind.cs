using MMSystem.Model.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMSystem.Model.ViewModel
{
    public class UserFind
    {


        public int UserId { get; set; }
        public string UserName { get; set; }
        public bool state { get; set; } 
        public string department_name { get; set; }

    }
}
