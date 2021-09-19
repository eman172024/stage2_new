using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMSystem.Model.ViewModel
{
    public class PagenationSendedEmail<t>
    {

        public int Total { get; set; }

        public List<t> mail { get; set; }

    }
}
