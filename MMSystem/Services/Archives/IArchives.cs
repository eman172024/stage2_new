using MMSystem.Model.ViewModel.ArchivesReport;
using MMSystem.Model.ViewModel.ArchiveVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMSystem.Services.Archives
{
   public interface IArchives
    {
        Task<ArchiveVModelWithPag> GetAll(int page,int pageSize,int? mail_number,DateTime? date_time_of_day, DateTime? date_time_from, int? department_id,int? side_id,string? mail_summary, int? get_all, int? MailType, int? Perent);

        Task<bool> UpdateExternal(UpdateArchiveViewModel model);
        Task<bool> UpdateExternals(UpdateArchiveViewModel model);


    }
}
