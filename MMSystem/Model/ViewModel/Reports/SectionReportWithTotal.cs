using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMSystem.Model.ViewModel.Reports
{
    public class SectionReportWithTotal
    {
      public List<SectionReport> SectionReport { get; set; }

      public TotalCounts TotalOfTotal { get; set; } = new TotalCounts();
    }
}
