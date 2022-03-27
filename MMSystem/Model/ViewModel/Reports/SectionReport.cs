using MMSystem.Model.ViewModel.Reports;


namespace MMSystem.Model.ViewModel
{
    public class SectionReport
    {
        public string DepartmentName { get; set; }
        public TotalCounts TotalOfReceived { get; set; } = new TotalCounts();

    }
}
