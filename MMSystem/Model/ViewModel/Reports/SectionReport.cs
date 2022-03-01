using MMSystem.Model.ViewModel.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMSystem.Model.ViewModel
{
    public class SectionReport
    {
        public string DepartmentName { get; set; }
        public TotalCounts TotalOfReceived { get; set; } = new TotalCounts();

    }
}
