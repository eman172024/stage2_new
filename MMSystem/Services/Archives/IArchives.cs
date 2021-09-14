using MMSystem.Model.ViewModel.ArchivesReport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMSystem.Services.Archives
{
   public interface IArchives
    {
        Task<List<ArchivesViewModel>> GetAll(int page,int pageSize);

        Task<bool> UpdateExternal(UpdateArchiveViewModel model);

    }
}
