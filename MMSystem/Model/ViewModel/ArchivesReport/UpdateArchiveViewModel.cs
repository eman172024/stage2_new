using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMSystem.Model.ViewModel.ArchivesReport
{
    public class UpdateArchiveViewModel
    {
        public int Id { get; set; }
        public string delevery { get; set; }
        public DateTime Send_of_Ex_mail { get; set; }
        public bool Attachments { get; set; }
    }
}
