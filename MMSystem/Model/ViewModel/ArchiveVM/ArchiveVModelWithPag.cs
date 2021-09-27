using MMSystem.Model.ViewModel.ArchivesReport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMSystem.Model.ViewModel.ArchiveVM
{
    public class ArchiveVModelWithPag
    {

        public int total { get; set; }
        public List<ArchivesViewModel> list { get; set; } = new List<ArchivesViewModel>() { };
    }
}
