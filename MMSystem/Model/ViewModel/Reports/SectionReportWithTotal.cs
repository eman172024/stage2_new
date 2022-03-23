using System.Collections.Generic;


namespace MMSystem.Model.ViewModel.Reports
{
    public class SectionReportWithTotal
    {
      public List<SectionReport> SectionReport { get; set; }

      public TotalCounts TotalOfTotal { get; set; } = new TotalCounts();
    }
}
