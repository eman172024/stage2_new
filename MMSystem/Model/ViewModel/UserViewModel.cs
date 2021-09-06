using MMSystem.Model.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMSystem.Model.ViewModel
{
    public class UserViewModel
    {
        public AdministratorDto user { get; set; }

        public List<Role> roles { get; set; }
    }
}
