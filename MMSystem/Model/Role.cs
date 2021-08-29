using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MMSystem.Model
{
    public class Role
    {[Key]
        public int RoleId { get; set; }
        public string Name { get; set; }
        public List<UserRoles> userRoles { get; set; }


    }
}
