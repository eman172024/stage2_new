using MMSystem.Model.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMSystem.Model.ViewModel
{
    public class UserView
    {
      public  AdministratorDto Administrator { get; set; }
        //public int UserId { get; set; }
        //public string UserName { get; set; }
        //public string FirstMACAddress { get; set; }
        //public string SecandMACAddress { get; set; }
        //public string nationalNumber { get; set; }
        //public int DepartmentId { get; set; }                    
        public List<Role> Listrole { get; set; }

        //public int RoleId { get; set; }
        //public string Name { get; set; }
    }
}
