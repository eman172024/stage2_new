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
        Task<ArchiveVModelWithPag> GetAll(int page,int pageSize);

        Task<bool> UpdateExternal(UpdateArchiveViewModel model);
        Task<List<ArchivesViewModel>> GetByNum(int id);

    }
}
