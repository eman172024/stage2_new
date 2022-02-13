using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMSystem.Model.ViewModel.ArchivesReport
{
    public class UpdateArchiveViewModel
    {
        public int MailId { get; set; }
        public int Current { get; set; }

        public string delevery { get; set; }
        public DateTime Send_of_Ex_mail { get; set; }
        public bool Attachments { get; set; }
        public int Number_Of_Copies { get; set; }
        public string note { get; set; }
    }
}
