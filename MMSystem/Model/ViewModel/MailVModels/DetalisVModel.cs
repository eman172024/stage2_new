using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMSystem.Model.ViewModel.MailVModels
{
    public class DetalisVModel
    {
        public int total { get; set; }
        public List<SendsDetalies> sendsDetalies { get; set; } = new List<SendsDetalies>();

    }
}
