using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMSystem.Model.ViewModel.Reports
{
    public class TotalCounts
    {
        public Decimal TotalOfMassage { get; set; }
        public Decimal TotalOfReplay { get; set; }
        public Decimal TotalOfNotReplay { get; set; }
        public Decimal Average { get; set; }

    }
}
