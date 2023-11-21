using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMSystem.Model.ViewModel
{
    public class ResendViewModel
    {

        public int Mail_id { get; set; }
        public int userid { get; set; }
        public List<ActionResender> actionSenders { get; set; }

    }
}
