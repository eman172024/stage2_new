using MMSystem.Model.Dto;
using System.Collections.Generic;


namespace MMSystem.Model.ViewModel
{
    public class UserView
    {
        public UserView()
        {
            this.Listrole = new List<Role>();
        }
        public  AdministratorDto Administrator { get; set; }                  
        public List<Role> Listrole { get; set; }

    }
}
