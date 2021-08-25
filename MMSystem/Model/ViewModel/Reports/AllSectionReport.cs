using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMSystem.Model.ViewModel
{
    public class AllSectionReport
    {
        public string DepartmentName { get; set; }
        public int TotalOfMassage { get; set; }
        public int TotalOfReplay { get; set; }
        public int TotalOfNotReplay { get; set; }
        public decimal Average { get; set; }
      
    }
}
