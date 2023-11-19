using MMSystem.Model.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMSystem.Model.ViewModel
{
    public class UserWithOnlyRoleNum
    {

        public UserWithOnlyRoleNum()
        {
            this.Listrole = new List<string>();
        }
        
        public int parent_id { get; set; }
        public string parent_name { get; set; }
        public AdministratorDto Administrator { get; set; }
        public List<string> Listrole { get; set; }


    }
}
