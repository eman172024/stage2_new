using MMSystem.Model.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMSystem.Model.ViewModel
{
    public class UserAddORUpdate
    {
        public Administrator Administrator { get; set; }
        public List<int> Listrole { get; set; }

        public int currentUser { get; set; }
}
}
