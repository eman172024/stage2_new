using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMSystem.Model
{
    public class Login
    {
        public int DepartmentId { get; set; }
        public int UserId { get; set; }
        public string Password { get; set; }
       
        //*******21/12/2022
        public string Mac { get; set; }
        //********end 21/12/2022


    }
}
